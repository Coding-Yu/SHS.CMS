using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using SHS.Infra.Data.Users;
using SHS.Infrastructu.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHS.Authorization
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public ResourceOwnerPasswordValidator()
        {
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            List<User> users = null;
            using (var db = new CMSContext())
            {

                users = (from u in db.Users
                         where u.Name == context.UserName
                         where u.Password == context.Password
                         orderby u.CreateDate
                         select u).ToList();
            }

            //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
            if (users.Count > 0)
            {
                try
                {
                    foreach (var item in users)
                    {
                        context.Result = new GrantValidationResult(
                         subject: context.UserName,
                         authenticationMethod: "custom",
                         claims: GetUserClaims(item));
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
        }

        //可以根据需要设置相应的Claim
        private Claim[] GetUserClaims(User user)
        {
            return new Claim[]
            {
            new Claim("icon",user.Icon.ToString()),
            new Claim("UserId", user.ID.ToString()),
            new Claim(JwtClaimTypes.Name,user.Name),
            new Claim(JwtClaimTypes.Email, user.Email),
            new Claim(JwtClaimTypes.Role,user.RoleID.ToString())
            };
        }
    }
}
