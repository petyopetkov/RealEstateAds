namespace RealEstateAds.Api.Models.RealEstates
{
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;

    public class RealEstateBaseResponceModel : IMapFrom<RealEstate>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }
    }
}