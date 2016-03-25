namespace RealEstateAds.Services.Contracts
{
    using System.Linq;

    using RealEstateAds.Models;

    public interface IRealEstatesServices
    {
        IQueryable<RealEstate> GetAll(int skip, int take);

        RealEstate GetById(int id);

        RealEstate Create(RealEstate newRealEstate);
    }
}
