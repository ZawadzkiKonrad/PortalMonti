using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public CommentRepository(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            _context = context;
            _userManager = userManager;
            _accessor = accessor;
        }
        public int AddComment(Comment Comment)
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            _context.Comments.Add(Comment);
            _context.SaveChanges();
            return Comment.Id;
        }

        public IQueryable<Comment> GetAllComments(int postId)
        {
            //var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;

            var comments = _context.Comments.Where(i => i.PostId == postId);

            return comments;
        }

        public IQueryable<Comment> GetFullComment()
        {
            var comments = _context.Comments;
            return comments;
        }
    }
}
