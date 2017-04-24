using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Blog.DataAccess.Context;

namespace Blog.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Blog.Model.Posts.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });
        }
    }
}
