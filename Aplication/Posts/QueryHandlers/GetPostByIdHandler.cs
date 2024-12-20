﻿using System;
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
    public class GetPostByIdHandler : IRequestHandler<GetPostById,Post>
    {

        private readonly IPostRepository _postRepo;

        public GetPostByIdHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            var post = await _postRepo.GetPostById(request.PostId);
            return post;
        }
    }
}
