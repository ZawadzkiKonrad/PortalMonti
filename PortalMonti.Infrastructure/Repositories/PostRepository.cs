using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
           private readonly Context _context;
    public PostRepository(Context context)
    {
        _context = context;
    }
    
        public void DeletePost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

        }

        public int AddPost(Domain.Model.Post post )
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post.Id;

        }
        public Post GetPostById(int postId)
        {
            var post=_context.Posts.FirstOrDefault(p => p.Id == postId);
            return post;
        }
        public IQueryable<Post> GetPostsByTagId(int tagId)
        {
            var posts = _context.PostTag.Where(i => i.TagId == tagId);
            return (IQueryable<Post>)posts;
        }

        public IQueryable<Post> GetAllPosts()
        {
            var posts = _context.Posts;
            return posts;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }

        //Post IPostRepository.GetPostById(int postId)
        //{
        //    return _context.Posts.FirstOrDefault(p => p.Id == postId);
        //}
    }
}
