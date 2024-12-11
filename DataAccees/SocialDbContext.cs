using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcceess
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions opt) : base(opt)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBluilder)
        {
            modelBluilder.Entity<Student>()
                .HasMany(x => x.Classes)
                .WithMany(y => y.Students)
                .UsingEntity(j => j.ToTable("ClassStudent"));
        }
    }
}
