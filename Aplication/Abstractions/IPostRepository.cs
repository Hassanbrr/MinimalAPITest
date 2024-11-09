using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetPostWithComments();
        Task<Post> GetPostWithComments(int postId);
        Task<Post> CreatePost(Post ToCreate);
        Task<Post> UpdatePost(string updateContent,int postId  );
        Task DeletePost(int postId);
    }
}
