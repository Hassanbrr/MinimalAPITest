
//using Application.Abstractions;
//using Domain.Models;
//using Microsoft.EntityFrameworkCore;

//namespace DataAcceess.Repositories
//{
//    public class PostRepository : IPostRepository
//    {
//        private readonly SocialDbContext _ctx;

//        public PostRepository(SocialDbContext ctx)
//        {
//            _ctx = ctx;
//        }
//        public async Task<Student> CreatePost(Student toCreate)
//        {
//            toCreate.DateCreated = DateTime.Now;
//            toCreate.LastModified = DateTime.Now;
//            _ctx.Posts.Add(toCreate);
//            await _ctx.SaveChangesAsync();
//            return toCreate;

//        }

//        public async Task DeletePost(int postId)
//        {
//             var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);

//             if (post == null) return;
//             _ctx.Posts.Remove(post);
//             await _ctx.SaveChangesAsync();

//        }
//        public  async Task<ICollection<Student>> GetAllPosts()
//        {
//            return await _ctx.Posts.ToListAsync();
//        }

//        public async Task<Student> GetPostById(int postId)
//        {
//            return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
//        }


//        public async Task<Student> UpdatePost(string updateContent, int postId)
//        {
//            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
//            post.LastModified = DateTime.Now;
//            post.Content = updateContent;
//            await _ctx.SaveChangesAsync();
//            return post;

//        }

//    }
//}
