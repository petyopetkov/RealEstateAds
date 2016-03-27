namespace RealEstateAds.Api.Controllers
{
    using System.Web.Http;

    using Models.Users;
    using RealEstateAds.Services.Contracts;
    
    public class UsersController : BaseController
    {
        private readonly IUsersServices users;

        public UsersController(IUsersServices users)
        {
            this.users = users;
        }

        public IHttpActionResult Get(string id)
        {
            var user = this.users.GetUserByUserName(id);
            if (user == null)
            {
                return this.NotFound();
            }

            var result = this.Mapper.Map<UserResponceModel>(user);
            result.CommentsCount = user.Comments.Count;
            result.RealEstatesCount = user.RealEstates.Count;

            return this.Ok(result);
        }
    }
}
