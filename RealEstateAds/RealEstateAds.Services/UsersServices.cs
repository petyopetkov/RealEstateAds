namespace RealEstateAds.Services
{
    using System.Linq;

    using Data;
    using RealEstateAds.Models;
    using RealEstateAds.Services.Contracts;

    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetByUserName(string userName)
        {
            return this.users.All()
                .FirstOrDefault(u => u.UserName == userName);
                
        }

        public void RateUser(string id, int value)
        {
            var user = this.users.GetById(id);
            var newRating = new Rating()
            {
                Value = value,
                AuthorId = id
            };

            user.RatingCollection.Add(newRating);
            user.Rating = user.RatingCollection.Average(r => r.Value);

            this.users.Update(user);
            this.users.SaveChanges();
        }
    }
}
