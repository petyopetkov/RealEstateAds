namespace RealEstateAds.Api.Models.RealEstates
{
    using Common;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;
    using System.ComponentModel.DataAnnotations;
    public class RealEstateRequestModel : IMapTo<RealEstate>
    {
        [Required]
        [MinLength(ValidationConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength)]
        [MaxLength(ValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ValidationConstants.AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ContactMaxLength)]
        public string Contact { get; set; }

        [Required]
        [Range(ValidationConstants.ConstructionYearMin, ValidationConstants.ConstructionYearMax)]
        public int ConstructionYear { get; set; }

        public decimal? RentingPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        [Required]
        public RealEstateType Type { get; set; }
    }
}