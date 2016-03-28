namespace RealEstateAds.Api.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;
    
    public class CommentRequestModel : IMapTo<Comment>
    {
        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength)]
        [MaxLength(ValidationConstants.CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int RealEstateId { get; set; }
    }
}