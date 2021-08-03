using AutoMapper;
using AutoMapper.QueryableExtensions;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepo,IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }
        public int AddPost(NewPostVm post)
        {
            throw new NotImplementedException();
        }

        public ListPostForListVm GetAllPostForList()
        {
            var posts = _postRepo.GetAllPosts().ProjectTo<PostForListVm>(_mapper.ConfigurationProvider).ToList();
            var postList = new ListPostForListVm()
            {
                Posts = posts,
                Count = posts.Count
            };
            return postList;
           
        }
        public PostDetailsVm GetPostById(int postId)
        {

            var post = _postRepo.GetPostById(postId);
            
            var postVm = _mapper.Map<PostDetailsVm>(post);
          
            //var postVm = _mapper.Map<PostDetailsVm>(post).ProjectTo<PostDetailsVm>(_mapper.ConfigurationProvider);


            return postVm;
        }
    }
}
