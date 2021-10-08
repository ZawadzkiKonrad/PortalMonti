using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Domain.Interfaces
{
    public interface IPostRepository
    {
        void DeletePost(int id);

        int AddPost(Domain.Model.Post post);

        Post GetPostById(int id);

        IQueryable<Post> GetPostsByTagId(int tagId);

        IQueryable<Post> GetAllPosts();

        IQueryable<Tag> GetAllTags();
        void UpdatePost(Post post);
        void UpdateImage(string path, AppUser user);
        void UpdateImageCom(string path, AppUser user);
    }
}
