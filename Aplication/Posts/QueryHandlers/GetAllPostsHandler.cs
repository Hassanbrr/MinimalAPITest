using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers
{
    public class GetAllPostsHandler :IRequestHandler<GetAllPosts,ICollection<Post>>
    {
        private readonly IPostRepository _postRepo;

        public GetAllPostsHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            var posts =   _postRepo.GetAllPosts( );
            return await posts;
        }
    }
}
