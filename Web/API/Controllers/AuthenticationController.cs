using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SHS.Infrastructu.Encrypt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

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
            AythenticationOutputMessageModel model = new AythenticationOutputMessageModel();
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
        [HttpPost("Test")]
        public async Task<JsonResult> Test(string token)
        {
            // call api
            var client = new HttpClient();
            client.SetBearerToken(token);

            var response = await client.GetAsync("http://localhost:5001/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
                return Json(JArray.Parse(content));
            }
            return Json(response.Content);
        }
        [HttpPost("GetUser")]
        public async Task<JsonResult> GetUser(string token)
        {
            // call api
            var client = new HttpClient();
            client.SetBearerToken(token);

            var response = await client.GetAsync("http://localhost:5001/api/User/get?id=937F6ED9-C753-4305-8F87-BEB98857EC6C");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return Json(content);
            }
            return Json(response.Content);
        }
    }
}