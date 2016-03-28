namespace RealEstateAds.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Common;
    using Models.RealEstates;
    using Microsoft.AspNet.Identity;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;
    using Services.Contracts;

    [Authorize]
    public class RealEstatesController : BaseController
    {
        private readonly IRealEstatesServices realEstates;

        public RealEstatesController(IRealEstatesServices realEstates)
        {
            this.realEstates = realEstates;
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int skip = GlobalConstants.SkipValue, int take = GlobalConstants.TakeValue)
        {
            var result = this.realEstates
                .GetAll(skip, take)
                .To<RealEstateBaseResponceModel>()
                .ToList();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var realEstate = this.realEstates
                .GetById(id);

            if (realEstate == null)
            {
                return this.NotFound();
            }

            if (this.User.Identity.IsAuthenticated)
            {
                var result = this.Mapper.Map<RealEstatePrivateDetailsResponceModel>(realEstate);

                return this.Ok(result);
            }
            else
            {
                var result = this.Mapper.Map<RealEstatePublicDetailsResponceModel>(realEstate);

                return this.Ok(result);
            }            
        }

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
