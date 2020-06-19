using AutoMapper;
using SHS.Application.AreaAppService.Dtos;
using SHS.Application.ArticleAppService.Dtos;
using SHS.Application.CategoryAppService.Dtos;
using SHS.Application.LogAppService.Dtos;
using SHS.Application.PermissionAppService.Dtos;
using SHS.Application.RoleAppService.Dtos;
using SHS.Application.TagAppService.Dtos;
using SHS.Application.UserAppService.Dtos;
using SHS.Domain.Core.Area;
using SHS.Domain.Core.Articles;
using SHS.Domain.Core.Categorys;
using SHS.Domain.Core.Logger;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Domain.Core.Tags;
using SHS.Infra.Data.Users;
using System;
using System.Reflection;

namespace SHS.Application.AutoMapper
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            var configuration = new MapperConfiguration(
                cfg =>
                {
                    //cfg.CreateMap<Guid, string>().ConvertUsing(new GuidTypeConverter());
                    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType());
                });

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

            #region area
            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>();

            CreateMap<Area, AddAreaDto>();
            CreateMap<AddAreaDto, Area>();

            CreateMap<Area, ModifyAreaDto>();
            CreateMap<ModifyAreaDto, Area>();
            #endregion

            #region article
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<Article, AddArticleDto>();
            CreateMap<AddArticleDto, Article>();

            CreateMap<Article, ModifyArticleDto>();
            CreateMap<ModifyArticleDto, Article>();
            #endregion

            #region category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, AddCategoryDto>();
            CreateMap<AddCategoryDto, Category>();

            CreateMap<Category, ModifyCategoryDto>();
            CreateMap<ModifyCategoryDto, Category>();
            #endregion

            #region permission
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();

            CreateMap<Permission, AddPermissionDto>();
            CreateMap<AddPermissionDto, Permission>();

            CreateMap<Permission, PermissionAppService.Dtos.ModifyPermissionDto>();
            CreateMap<PermissionAppService.Dtos.ModifyPermissionDto, Permission>();
            #endregion

            #region tag
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();

            CreateMap<Tag, AddTagDto>();
            CreateMap<AddTagDto, Tag>();

            CreateMap<Tag, ModifyTagDto>();
            CreateMap<ModifyTagDto, Tag>();
            #endregion

            #region user
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();

            CreateMap<User, ModifyUserDto>();
            CreateMap<ModifyUserDto, User>();
            #endregion

            #region role
            CreateMap<Rolepermission, RoleDto>();
            CreateMap<RoleDto, Rolepermission>();

            CreateMap<Rolepermission, AddRoleDto>();
            CreateMap<AddRoleDto, Rolepermission>();

            CreateMap<Rolepermission, ModifyRoleDto>();
            CreateMap<ModifyRoleDto, Rolepermission>();
            #endregion

            #region log
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            #endregion
        }
        public class GuidTypeConverter : ITypeConverter<Guid, String>
        {
            public string Convert(Guid source, string destination, ResolutionContext context)
            {
                return System.Convert.ToString(source);
            }
        }

    }
}
