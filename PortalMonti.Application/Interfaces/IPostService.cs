using PortalMonti.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.Interfaces
{
   public interface IPostService
    {
       ListPostForListVm GetAllPostForList(int pageSize,int? pageNo,string searchString);
        int AddPost(NewPostVm post);
        PostDetailsVm GetPostById(int id);
        NewPostVm GetPostForEdit(int id);
        void UpdatePost(NewPostVm model);
        void DeletePost(int id);
    }
}
