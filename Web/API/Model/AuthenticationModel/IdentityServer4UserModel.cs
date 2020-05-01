using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.AuthenticationModel
{
    public class IdentityServer4UserModel
    {
        //,"UserId":"06bdad3c-e472-494b-9cf3-9c0974012ad6","name":"admin","email":"1076372177@qq.com","role":"f8a6526e-6131-40fe-8472-4cf74da15c9b","amr":"custom"}
        public string sub { get; set; }
        public string auth_time { get; set; }
        public string idp { get; set; }
        public string icon { get; set; }
        public string UserId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string amr { get; set; }
    }
}
