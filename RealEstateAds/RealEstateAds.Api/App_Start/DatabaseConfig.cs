namespace RealEstateAds.Api
{
    using System.Data.Entity;
    using RealEstateAds.Data;
    using RealEstateAds.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RealEstateAdsDbContext, Configuration>());
            RealEstateAdsDbContext.Create().Database.Initialize(true);
        }
    }
}