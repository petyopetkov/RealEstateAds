namespace RealEstateAds.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using RealEstateAds.Models;

    public class RealEstateAdsDbContext : IdentityDbContext<User>, IRealEstateAdsDbContext
    {
        public RealEstateAdsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<RealEstate> RealEstates { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public static RealEstateAdsDbContext Create()
        {
            return new RealEstateAdsDbContext();
        }
    }
}
