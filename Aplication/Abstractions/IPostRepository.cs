using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Student>> GetAllPosts();
        Task<Student> GetPostById(int postId);
        Task<Student> CreatePost(Student toCreate);
        Task<Student> UpdatePost(string updateContent,int postId  );
        Task DeletePost(int postId);
    }
}
