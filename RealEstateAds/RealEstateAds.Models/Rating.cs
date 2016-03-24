namespace RealEstateAds.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Value { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
