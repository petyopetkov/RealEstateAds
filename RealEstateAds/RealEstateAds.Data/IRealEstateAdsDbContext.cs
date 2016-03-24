namespace RealEstateAds.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IRealEstateAdsDbContext
    {
        IDbSet<Comment> Comments { get; set; }

        IDbSet<RealEstate> RealEstates { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
