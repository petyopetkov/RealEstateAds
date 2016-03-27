namespace RealEstateAds.Services.Contracts
{
    using RealEstateAds.Models;

    public interface IUsersServices
    {
        string GetUserNameById(string id);

        User GetByUserByName(string userName);

        void RateUser(string id, int value);
    }
}
