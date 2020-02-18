using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SHS.Application.UserAppService;
using SHS.Infrastructu.Encrypt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IUserAppService _userAppService;
        public AuthenticationController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("RequstToken")]
        public async Task<JsonResult> RequstToken(AuthenticationInputModel input)
        {
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
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "API"
            });
            AuthenticationOutputMessageModel model = new AuthenticationOutputMessageModel();
            if (tokenResponse.IsError)
            {
                model.Code = 50008;
                model.Message = tokenResponse.Error;
                return Json(model);
            }
            model.Code = 20000;
            model.Data = tokenResponse;
            return Json(model);
        }
        [HttpPost("GetUser")]
        public async Task<JsonResult> GetUser()//AuthenticationGetUserInputModel input
        {

            //var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000/");
            //if (disco.IsError)
            //{
            //    return Json(disco.Error);
            //}

            //// request User Info
            //var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest()
            //{
            //    Token = input.token,
            //    ClientId = "client",
            //    ClientSecret = "secret",
            //    Address = disco.UserInfoEndpoint,
            //});

            //AuthenticationGetUserOutputModel model = new AuthenticationGetUserOutputModel();
            //if (userInfoResponse.IsError)
            //{
            //    model.Code = 500;
            //    model.Message = userInfoResponse.Error;
            //    return Json(model);
            //}
            //model.Code = 200;
            //model.Data = userInfoResponse.Claims;
            //return Json(model);
            //TODO 改为授权系统通过token查询用户信息
            //String token = "";
            //StringValues tokenhead = "";
            //Request.Headers.TryGetValue("Authorization", out tokenhead);
            //var client = new HttpClient();
            //var result = new AuthenticationGetUserOutputModel();

            //var requestJson = JsonConvert.SerializeObject("[{'id':'937F6ED9-C753-4305-8F87-BEB98857EC6C'}]");
            //token= tokenhead.ToString().Substring(6);

            //HttpContent httpContent = new StringContent(requestJson);
            //var response = await client.PostAsync("http://localhost:5001/api/User/get", httpContent);
            //client.DefaultRequestHeaders.Add("Bearer ", token);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var content = await response.Content.ReadAsStringAsync();
            //if (!response.IsSuccessStatusCode)
            //{
            //    result.Code = 500;
            //    result.Message = content;
            //}
            //else
            //{
            //    result.Code = 200;
            //    result.Data = content;
            //}
            var result = new AuthenticationGetUserOutputModel();
            var user = await _userAppService.GetUser("937F6ED9-C753-4305-8F87-BEB98857EC6C");
            result.Code = 200;
            result.Data = user;
            return Json(result);
        }
    }
}