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

        public static RealEstateAdsDbContext Create()
        {
            return new RealEstateAdsDbContext();
        }
    }
}
