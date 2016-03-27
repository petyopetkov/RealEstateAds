namespace RealEstateAds.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength)]
        [MaxLength(ValidationConstants.CommentContentMaxLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [ForeignKey("RealEstate")]
        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}