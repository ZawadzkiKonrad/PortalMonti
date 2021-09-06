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
        public CommentRepository(Context context)
        {
            _context = context;
        }
        public int AddComment(Comment Comment)
        {
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
    }
}
