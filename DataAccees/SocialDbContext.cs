using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcceess
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions opt) : base(opt)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
      
    }
}
