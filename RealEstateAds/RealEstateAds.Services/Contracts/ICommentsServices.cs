namespace RealEstateAds.Services.Contracts
{
    using System.Linq;

    using RealEstateAds.Models;

    public interface ICommentsServices
    {
        IQueryable<Comment> GetAll();

        Comment GetById(int id);

        Comment Create(Comment newRealEstate);
    }
}
