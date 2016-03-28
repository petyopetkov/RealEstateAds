namespace RealEstateAds.Services
{
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

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All()
                .OrderByDescending(c => c.CreatedOn);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }
    }
}
