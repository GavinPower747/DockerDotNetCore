using Blog.Model.Posts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccess.Mappings
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Created).IsRequired();
            entityBuilder.Property(p => p.LastModified).IsRequired();
            entityBuilder.Property(p => p.AuthorName).HasMaxLength(50).IsRequired();
            entityBuilder.Property(p => p.Content).IsRequired();
        }
    }
}