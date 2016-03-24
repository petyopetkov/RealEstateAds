namespace RealEstateAds.Services
{
    using System;
    using System.Linq;

    using Common;
    using Data;
    using RealEstateAds.Models;
    using RealEstateAds.Services.Contracts;
    
    public class CommentsServices : ICommentsServices
    {
        private IRepository<Comment> comments;

        public CommentsServices(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment Create(Comment newComment)
        {
            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment;
        }

        public IQueryable<Comment> GetAll(int skip = GlobalConstants.SkipValue, int take = GlobalConstants.TakeValue)
        {
            return this.comments.All()
                .OrderByDescending(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }
    }
}
