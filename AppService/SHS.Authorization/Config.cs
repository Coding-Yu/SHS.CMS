using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using SHS.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace SHS.Authorization
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("API", "SHS.CMS.API")
                //new ApiResource(){
                // Name="API",
                // DisplayName="SHS.CMS.API",
                // //Scopes={
                // //       new Scope(){
                // //           Name="API.full_access",
                // //           DisplayName="full access to API",
                // //       }
                // //}
                // }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes =GrantTypes.ResourceOwnerPassword, //GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "API"
                    },
                    AllowOfflineAccess = true

                }
            };
        }

        internal static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
             {
                new IdentityResources.OpenId()
             };
        }

        public static List<TestUser> GetUsers()
        {
            using (var context = new CMSContext())
            {
                var user = context.Users.ToList();
                var testUser = new List<TestUser>();
                foreach (var item in user)
                {
                    testUser.Add(new TestUser()
                    {
                        SubjectId = item.ID.ToString(),
                        Username = item.Name,
                        Password = item.Password,
                    });
                }
                return testUser;
            }
            //return new List<TestUser>
            //{
            //    new TestUser
            //    {
            //        SubjectId = "1",
            //        Username = "alice",
            //        Password = "password"
            //    },
            //    new TestUser
            //    {
            //        SubjectId = "2",
            //        Username = "bob",
            //        Password = "password"
            //    }
            //};
        }
    }
}
