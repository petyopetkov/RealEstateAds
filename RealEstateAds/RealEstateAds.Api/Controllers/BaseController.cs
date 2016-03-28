namespace RealEstateAds.Api.Controllers
{
    using System.Web.Http;

    using AutoMapper;
    using RealEstateAds.Api.Infrastructure.Mapping;

    public abstract class BaseController : ApiController
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}