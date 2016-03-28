namespace RealEstateAds.Api.Models.Users
{
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;

    public class UserResponceModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public int RealEstatesCount { get; set; }

        public int CommentsCount { get; set; }

        public double Rating { get; set; }
    }
}