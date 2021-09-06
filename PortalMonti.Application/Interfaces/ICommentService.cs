using PortalMonti.Application.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Interfaces
{
    public interface ICommentService
    {
        IQueryable<CommentVm> GetAllComment(int postId);
        int AddComment(NewCommentVm comment);
      
    }
}
