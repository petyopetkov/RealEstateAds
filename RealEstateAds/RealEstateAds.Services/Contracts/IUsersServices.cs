namespace RealEstateAds.Services.Contracts
{
    using RealEstateAds.Models;

    public interface IUsersServices
    {
        User GetByUserName(string userName);

        void RateUser(string id, int value);
    }
}
