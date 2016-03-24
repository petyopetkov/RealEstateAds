namespace RealEstateAds.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using System.ComponentModel.DataAnnotations.Schema;
    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.TitleMinLength)]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength)]
        [MaxLength(ValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(ValidationConstants.ConstructionYearMin, ValidationConstants.ConstructionYearMax)]
        public int ConstructionYear { get; set; }

        [Required]
        [MaxLength(ValidationConstants.AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ContactMaxLength)]
        public string Contact { get; set; }

        public RealEstateType Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool CanBeRented { get; set; }

        public bool CanBeSold { get; set; }

        public decimal? RentingPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }
    }
}
