namespace RealEstateAds.Services
{
    using System.Linq;

    using Common;
    using Data;
    using RealEstateAds.Models;
    using RealEstateAds.Services.Contracts;
    
    class RealEstatesService : IRealEstatesServices
    {
        private IRepository<RealEstate> realEstates;

        public RealEstatesService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public RealEstate Create(RealEstate newRealEstate)
        {
            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate;
        }

        public IQueryable<RealEstate> GetAll(int skip = GlobalConstants.SkipValue, int take = GlobalConstants.TakeValue)
        {
            if (take > GlobalConstants.TakeValue)
            {
                take = GlobalConstants.TakeValue;
            }

            return this.realEstates.All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public RealEstate GetById(int id)
        {
            return this.realEstates.GetById(id);
        }
    }
}
