namespace RealEstateAds.Api.Controllers
{
    using System;
    using System.Linq;

    using Common;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Services.Contracts;
    using System.Web.Http;
    using RealEstateAds.Models;
    
    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsServices comments;
        private readonly IUsersServices users;

        public CommentsController(ICommentsServices comments, IUsersServices users)
        {
            this.comments = comments;
            this.users = users;
        }

        public IHttpActionResult Get(int id, int skip = GlobalConstants.SkipValue, int take = GlobalConstants.TakeValue)
        {
            if (skip < GlobalConstants.SkipValue)
            {
                skip = GlobalConstants.SkipValue;
            }

            if (take < 0 || take > GlobalConstants.TakeValue)
            {
                take = GlobalConstants.TakeValue;
            }

            var result = this.comments
                .GetAll()
                .Where(c => c.RealEstateId == id)
                .Skip(skip)
                .Take(take)
                .To<CommentResponceModel>()
                .ToList();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Post(CommentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var authorId = this.User.Identity.GetUserId();
            var authorName = this.users.GetUserNameById(authorId);

            var newComment = this.Mapper.Map<Comment>(model);
            newComment.AuthorId = authorId;
            newComment.CreatedOn = DateTime.Now;
            this.comments.Create(newComment);

            var result = this.Mapper.Map<CommentResponceModel>(newComment);
            result.AuthorName = authorName;
            return this.Created("", result);
        }

        [Route("api/Comments/ByUser/{id}")]
        [HttpGet]
        public IHttpActionResult ByUser(string id, int skip = GlobalConstants.SkipValue, int take = GlobalConstants.TakeValue)
        {
            if (skip < GlobalConstants.SkipValue)
            {
                skip = GlobalConstants.SkipValue;
            }

            if (take < 0 || take > GlobalConstants.TakeValue)
            {
                take = GlobalConstants.TakeValue;
            }
            

            var result = this.comments
                .GetAll()
                .Where(c => c.Author.UserName == id)
                .To<CommentResponceModel>()
                .Skip(skip)
                .Take(take)
                .ToList();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }
    }
}
