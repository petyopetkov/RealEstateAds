namespace RealEstateAds.Api.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    
    public class UserRateModel
    {
        [Required]
        public string UserId { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Value { get; set; }
    }
}