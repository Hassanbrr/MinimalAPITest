using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Hosting;
using MinimalApi.Abstractions;

namespace MinimalApi.EndPointDefinitions
{
    public class PostEndPointDefinition : IEndpointDefinition
    {
        public void RegisterEndPoints(WebApplication app)
        {

            var posts = app.MapGroup("/api/posts");
            posts.MapGet("/getById/{id}",GetPostById)
                .WithName("GetPostById");

            posts.MapPost("/create", CreatePost);

            posts.MapGet("/getAll",GetAll);

            posts.MapPut("/update/{id}", UpdatePost);

            posts.MapDelete("/delete/{id}",DeletePost);

        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { PostId = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        }
        private async Task<IResult> GetAll(IMediator mediator)
        {
            var getCommand = new GetAllPosts();
            var posts = await mediator.Send(getCommand);
            return TypedResults.Ok(posts);
        }
        private async Task<IResult> CreatePost(IMediator mediator, Post post )
        {
            var createPost = new CreatePost { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }
        private async Task<IResult> UpdatePost(IMediator mediator,Post post,int id )
        {
            var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return TypedResults.Ok(updatedPost);
        }
        private async Task<IResult> DeletePost(IMediator mediator,int id )
        {
            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return Results.NoContent();
        }
    }
}
