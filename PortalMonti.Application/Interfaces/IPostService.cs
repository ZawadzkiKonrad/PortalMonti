using PortalMonti.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.Interfaces
{
   public interface IPostService
    {
       ListPostForListVm GetAllPostForList();
        int AddPost(NewPostVm post);
        PostDetailsVm GetPostById(int postId);



    }
}
