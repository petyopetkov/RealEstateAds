﻿namespace RealEstateAds.Services
{
    using System.Linq;

    using Common;
    using Data;
    using RealEstateAds.Models;
    using RealEstateAds.Services.Contracts;
    
    public class RealEstatesServices : IRealEstatesServices
    {
        private IRepository<RealEstate> realEstates;

        public RealEstatesServices(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public RealEstate Create(RealEstate newRealEstate)
        {
            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate;
        }

        public IQueryable<RealEstate> GetAll(int skip, int take)
        {
            if (skip < GlobalConstants.SkipValue)
            {
                skip = GlobalConstants.SkipValue;
            }

            if (take > GlobalConstants.TakeValue || take < 0)
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
