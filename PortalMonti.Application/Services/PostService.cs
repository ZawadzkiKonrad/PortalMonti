using AutoMapper;
using AutoMapper.QueryableExtensions;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
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
            var pos = _mapper.Map<Domain.Model.Post>(post);
            var id = _postRepo.AddPost(pos);
            return id;
        }

      

        public void DeletePost(int id)
        {
            _postRepo.DeletePost(id);
        }

        public ListPostForListVm GetAllPostForList(int pageSize,int? pageNo,string searchString)
        {
            var posts = _postRepo.GetAllPosts().Where(p=>p.Name.StartsWith(searchString))
                .ProjectTo<PostForListVm>(_mapper.ConfigurationProvider).ToList();
            var postToShow = posts.Skip((int)(pageSize * (pageNo - 1))).Take(pageSize).ToList();
            var postList = new ListPostForListVm()
            {
                PageSize=pageSize,
                CurrentPage=pageNo,
                SearchString=searchString,
                Posts = postToShow,
                Count = posts.Count
            };
            return postList;
           
        }
        public PostDetailsVm GetPostById(int id)
        {
            var post = new Post();
            post = _postRepo.GetPostById(id);

            var postVm = _mapper.Map<PostDetailsVm>(post);         

            //var postVm = _mapper.Map<PostDetailsVm>(post).ProjectTo<PostDetailsVm>(_mapper.ConfigurationProvider);

            return postVm;
        }

        public NewPostVm GetPostForEdit(int id)
        {
            var post = _postRepo.GetPostById(id);
            var postVm = _mapper.Map<NewPostVm>(post);
            return postVm;
        }

        public void UpdatePost(NewPostVm model)
        {
            var post = _mapper.Map<Post>(model);
            _postRepo.UpdatePost(post);
        }
    }
}
