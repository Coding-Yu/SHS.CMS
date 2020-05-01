using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using SHS.Infrastructu.Encrypt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        [HttpPost("RequstToken")]
        public async Task<JsonResult> RequstToken(AuthenticationInputModel input)
        {
            //TODO 更新登录IP跟时间
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                return Json(disco.Error);
            }

            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                UserName = input.UserName,//"admin",
                Password = MD5Encrypt.EncryptBy32(input.Password),// "95ec2e295d99fa60fbb1e245175a25",
                ClientId = "client2",
                ClientSecret = "secret",
            });
            AuthenticationOutputMessageModel model = new AuthenticationOutputMessageModel();
            if (tokenResponse.IsError)
            {
                model.Code = 50008;
                model.Message = tokenResponse.Error;
                return Json(model);
            }
            model.Code = 20000;
            model.Data =tokenResponse;
            return Json(model);
        }
        [HttpGet("GetUser")]
        public async Task<JsonResult> GetUser()//AuthenticationGetUserInputModel input
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            token = token.ToString().Replace("Bearer", "").Trim().ToString();
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = "http://localhost:5000",
                ClientSecret = "secret",
            });//"http://localhost:5000"
            if (disco.IsError)
            {
                return Json(disco.Error);
            }

            // request User Info
            var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest()
            {

                Token = accessToken,
                Address = disco.UserInfoEndpoint,
            });

            AuthenticationGetUserOutputModel model = new AuthenticationGetUserOutputModel();
            if (userInfoResponse.IsError)
            {
                model.Code = 50008;
                model.Message = userInfoResponse.Error;
                return Json(model);
            }
            model.Code = 20000;
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var item in userInfoResponse.Claims)
            {
                result.Add(item.Type, item.Value);
            }
            var jsonResult = JsonConvert.SerializeObject(result);
            var resultEntity = JsonConvert.DeserializeObject<IdentityServer4UserModel>(jsonResult);
            model.Data = resultEntity;
            return Json(model);
        }
        [AllowAnonymous]
        [HttpGet("logout")]
        public async Task<JsonResult> Logout()
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            token = token.ToString().Replace("Bearer", "").Trim().ToString();

            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");//添加消息头
            var result = await client.RevokeTokenAsync(new TokenRevocationRequest
            {
                Address = "http://localhost:5000/connect/revocation",
                ClientId = "client2",
                ClientSecret = "secret",
                Token = token,
                TokenTypeHint = "access_token"

            });
            var model = new LogoutOutputModel();
            if (result.IsError)
            {
                model.Data = result.IsError;
                model.Code = 50008;
            }
            else
            {
                model.Data = result.IsError;
                model.Code = 20000;
            };


            return Json(model);
            //TODO 方法检验没问题，但是在author服务器没办法检测到这个token，是否需要数据库？
        }
    }
}