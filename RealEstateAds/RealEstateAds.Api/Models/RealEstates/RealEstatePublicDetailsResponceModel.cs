namespace RealEstateAds.Api.Models.RealEstates
{
    using System;
    using AutoMapper;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;

    public class RealEstatePublicDetailsResponceModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int ConstructionYear { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Type { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstatePublicDetailsResponceModel>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type));
        }
    }
}