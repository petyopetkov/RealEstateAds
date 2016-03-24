namespace RealEstateAds.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class User : IdentityUser
    {
        private ICollection<Rating> ratingCollection;
        private ICollection<RealEstate> realEstates;
        private ICollection<Comment> comments;

        public User()
        {
            this.ratingCollection = new HashSet<Rating>();
            this.realEstates = new HashSet<RealEstate>();
            this.comments = new HashSet<Comment>();
        }

        public double Rating { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
