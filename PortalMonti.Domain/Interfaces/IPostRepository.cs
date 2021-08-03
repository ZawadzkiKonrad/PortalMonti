using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Domain.Interfaces
{
    public interface IPostRepository
    {
        void DeletePost(int postId);

        int AddPost(Domain.Model.Post post);

        Post GetPostById(int postId);

        IQueryable<Post> GetPostsByTagId(int tagId);

        IQueryable<Post> GetAllPosts();

        IQueryable<Tag> GetAllTags();

    }
}
