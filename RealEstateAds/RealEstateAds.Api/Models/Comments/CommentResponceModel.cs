namespace RealEstateAds.Api.Models.Comments
{
    using System;

    using AutoMapper;
    using RealEstateAds.Api.Infrastructure.Mapping;
    using RealEstateAds.Models;
    
    public class CommentResponceModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentResponceModel>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}