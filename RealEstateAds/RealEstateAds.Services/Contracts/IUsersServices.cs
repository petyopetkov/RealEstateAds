namespace RealEstateAds.Services.Contracts
{
    using RealEstateAds.Models;

    public interface IUsersServices
    {
        string GetUserNameById(string id);

        User GetUserByUserName(string userName);

        void RateUser(string id, int value);
    }
}
