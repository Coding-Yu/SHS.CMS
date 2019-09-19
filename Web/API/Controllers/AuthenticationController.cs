using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Model.User;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using SHS.Infrastructu.Encrypt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        [HttpPost("RequstToken")]
        public async Task<JsonResult> RequstToken(AuthenticationModel model)
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
                UserName = model.Name,//"admin",
                Password = MD5Encrypt.EncryptBy32(model.Password),// "95ec2e295d99fa60fbb1e245175a25",
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "API"
            });

            if (tokenResponse.IsError)
            {
                return Json(tokenResponse.Error);
            }
            return Json(tokenResponse.AccessToken);
        }
    }
}