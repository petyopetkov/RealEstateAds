namespace RealEstateAds.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using RealEstateAds.Models;
    using RealEstateAds.Services.Contracts;
    using Models.RealEstates;
    public static class TestObjectFactory
    {
        private static IQueryable<RealEstate> realEstates = new List<RealEstate>
        {
            new RealEstate
            {
                Id = 1,
                CreatedOn = new DateTime(2016, 3, 1, 10, 10, 10, 10),
                Description = "Test Description",
                Title = "Test title",
                ConstructionYear = 2000,
                Address = "Address Test",
                Contact = "555-555-555",
                Type = 0,
                CanBeRented = true,
                CanBeSold = true,
                RentingPrice = 500,
                SellingPrice = 100000,
                AuthorId = "97bfc79b-896b-42a9-b20e-efff78508689"
            }
        }.AsQueryable();

        public static IRealEstatesServices GetRealEstatesServices()
        {
            var realEstatesServices = new Mock<IRealEstatesServices>();

            realEstatesServices.Setup(r => r.GetAll(It.IsAny<int>(), It.IsAny<int>())).Returns(realEstates);

            realEstatesServices.Setup(r => r.GetById(It.IsAny<int>())).Returns(realEstates.First);

            return realEstatesServices.Object;
        }

        public static RealEstateRequestModel GetInvalidModel()
        {
            var model = new RealEstateRequestModel { Title = "Test Title" };

            return model;
        }

        public static RealEstateRequestModel GetValidModel()
        {
            var model = new RealEstateRequestModel
            {
                Title = "Test Title",
                Description = "Test description",
                Address = "Test address",
                Contact = "666-666-666",
                ConstructionYear = 2000,
                RentingPrice = 500,
                SellingPrice = 100000,
                Type = 0,                
            };

            return model;
        }

        public static RealEstateRequestModel GetInvalidModelByPrice()
        {
            var model = new RealEstateRequestModel
            {
                Title = "Test Title",
                Description = "Test description",
                Address = "Test address",
                Contact = "666-666-666",
                ConstructionYear = 2000,
                Type = 0
            };

            return model;
        }
    }
}
