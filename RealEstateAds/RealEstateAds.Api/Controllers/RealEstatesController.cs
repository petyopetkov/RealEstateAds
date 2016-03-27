namespace RealEstateAds.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using Common;
    using Models.RealEstates;
    using Microsoft.AspNet.Identity;
    using RealEstateAds.Models;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using Services.Contracts;
    
    public class RealEstatesController : BaseController
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

        public IHttpActionResult Post(RealEstateRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model.SellingPrice == null && model.RentingPrice == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var newRealEstate = this.Mapper.Map<RealEstate>(model);
            newRealEstate.CreatedOn = DateTime.Now;
            newRealEstate.AuthorId = userId;

            if (newRealEstate.RentingPrice != null)
            {
                newRealEstate.CanBeRented = true;
            }

            if (newRealEstate.SellingPrice != null)
            {
                newRealEstate.CanBeSold = true;
            }

            this.realEstates.Create(newRealEstate);

            var result = this.Mapper.Map<RealEstateBaseResponceModel>(newRealEstate);
            return this.Created("", result);
        }
    }
}
