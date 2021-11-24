using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        IEnumerable<Post> GetUserPosts(string appUserId);
        IEnumerable<Post> GetPostsSearch(string searchString);
    }
}
