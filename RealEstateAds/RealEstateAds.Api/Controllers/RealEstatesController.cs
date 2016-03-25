namespace RealEstateAds.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using RealEstateAds.Models;
    using Services.Contracts;
    using Common;
    public class RealEstatesController : ApiController
    {
        private IRealEstatesServices realEstates;

        public RealEstatesController(IRealEstatesServices realEstates)
        {
            this.realEstates = realEstates;
        }

        //public IHttpActionResult Get(int skip, int take)
        //{
        //    if (skip < GlobalConstants.SkipValue)
        //    {
        //        return this.BadRequest("Skip must be positive number");
        //    }

        //    if (take < 0 || take > GlobalConstants.TakeValue)
        //    {
        //        return this.BadRequest("Take must be number between 0 and 100");
        //    }
        //}
    }
}
