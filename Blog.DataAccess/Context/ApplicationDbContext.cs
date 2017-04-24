using Blog.DataAccess.Mappings;
using Blog.Model.Posts;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new PostMap(builder.Entity<Post>());
        }
    }
}
