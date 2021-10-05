using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Interfaces
{
    public interface ICommentRepository
    {
        int AddComment(Comment Comment);
        IQueryable<Comment> GetAllComments(int postId);
        IQueryable<Comment> GetFullComment();
    }
}
