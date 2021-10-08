using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public PostRepository(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor)
    {
            _context = context;
            _userManager = userManager;
            _accessor = accessor;
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
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            post.Author = user.Email;
            post.AuthorImage = user.ImageProfile;
            post.Date = DateTime.Now;
            post.AuthorId = user.Id;
            user.Posts.Add(post);
            _context.SaveChanges();
            return post.Id;

        }
        public Post GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            
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

        public void UpdatePost(Post post)
        {
            _context.Attach(post);
            _context.Entry(post).Property("Name").IsModified = true;
            _context.Entry(post).Property("Text").IsModified = true;
            _context.Entry(post).Property("Date").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateImage(string path, AppUser user)
        {
            var posts = _context.Posts.Where(p => p.AuthorId == user.Id);
            foreach (var post in _context.Posts.Where(p => p.AuthorId == user.Id))
            {
                post.AuthorImage = path;
                

            }
            _context.SaveChanges();
        }

        public void UpdateImageCom(string path, AppUser user)
        {
            
            foreach (var com in _context.Comments.Where(p => p.AuthorId == user.Id))
            {
                com.ProfileImage = path;

            }
            _context.SaveChanges();
        }

        //Post IPostRepository.GetPostById(int postId)
        //{
        //    return _context.Posts.FirstOrDefault(p => p.Id == postId);
        //}
    }
}
