using AutoMapper;
using SHS.Application.ArticleAppService.Dtos;
using SHS.Application.UserAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.AutoMapper
{
    public class ModelToDtoAutoMapperConfig : Profile
    {
        public ModelToDtoAutoMapperConfig()
        {
            //var config = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType()));
            //var mapper = new Mapper(config);
            //#region article
            //var articleModel = new AddOrEditArticleModel();
            //var articleDto = mapper.Map<ArticleDto>(articleModel);
            //#endregion
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOrEditArticleModel, AddArticleDto>());
            //var addOrEditArticleModel = new AddOrEditArticleModel();
            //var mapper = new Mapper(config);
            //AddArticleDto dto = mapper.Map<AddArticleDto>(addOrEditArticleModel);

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AllowNullCollections = true;
            //    cfg.CreateMap<AddArticleDto, AddOrEditArticleModel>();
            //    cfg.CreateMap<AddOrEditArticleModel, AddArticleDto>();
            //});
            //var mapper = config.CreateMapper();
            ////var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType()));
            ////var mapper = new Mapper(configuration);

            //config.AssertConfigurationIsValid();

        }
    }
}
