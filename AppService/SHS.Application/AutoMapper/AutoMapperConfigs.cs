using AutoMapper;
using SHS.Application.PermissionAppService.Dtos;
using SHS.Application.RoleAppService.Dtos;
using SHS.Application.UserAppService.Dtos;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Infra.Data.Users;
using System;
using System.Reflection;

namespace SHS.Application.AutoMapper
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType()));

            var mapper = new Mapper(configuration);

            //role嵌套映射
            
            //   //映射发生之前
            //   .BeforeMap((source, dto) => {
            //        //可以较为精确的控制输出数据格式
            //        dto.CreateTime = Convert.ToDateTime(source.CreateTime).ToString("yyyy-MM-dd");
            //   })
            //   //映射发生之后
            //   .AfterMap((source, dto) => {
            //        //code ...
            //    });
            //CreateMap<User, UserDto>();
            //CreateMap<UserDto, User>();
            //CreateMap<ArticleDto, Article>();
            //CreateMap<Article, ArticleDto>();
        }
    }
}
