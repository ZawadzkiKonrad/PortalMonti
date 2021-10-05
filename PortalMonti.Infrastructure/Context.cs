using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Infrastructure
{
   public class Context : IdentityDbContext<AppUser> 
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReceivedMessage> Messages { get; set; }
        public DbSet<ReceivedMessage> ReceivedMessages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Image> Images { get; set; }
        public DbSet<PostTag> PostTag { get; set; } //tabela posrednia zostaje w liczbie poijedynczej
        public DbSet<Tag> Tags { get; set; }
        
        
        
        
        public Context(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //wiele do wielu:
            builder.Entity<PostTag>()
            .HasKey(pt => new { pt.PostId, pt.TagId });

            builder.Entity<PostTag>()
            .HasOne<Post>(pt => pt.Post)
            .WithMany(p => p.PostTags)
            .HasForeignKey(pt => pt.PostId);
            
            builder.Entity<PostTag>()
            .HasOne<Tag>(pt => pt.Tag)
            .WithMany(p => p.PostTags)
            .HasForeignKey(pt => pt.TagId);
        }
    }
}
