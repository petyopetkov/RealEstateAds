namespace RealEstateAds.Api.Controllers
{
    using System.Web.Http;

    using Models.Users;
    using RealEstateAds.Services.Contracts;
    using Microsoft.AspNet.Identity;
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

        [Authorize]
        [Route("api/Users/Rate")]
        [HttpPut]
        public IHttpActionResult Rate(UserRateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentUserId = this.User.Identity.GetUserId();
            if (currentUserId == model.UserId)
            {
                return this.BadRequest("You can not rate yourself");
            }

            this.users.RateUser(model.UserId, model.Value);

            return this.Ok();
        }
    }
}
