using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PortalMonti.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostService(IPostRepository postRepo,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public int AddPost(NewPostVm post)
        {
            
            
            var userId = _httpContextAccessor.HttpContext.User.Identity.Name; //pobieranie wlasciwosci zalogowanego usera sam emial lub name
            var pos = _mapper.Map<Domain.Model.Post>(post);
            pos.Date = DateTime.Now;
            pos.Author = userId;
            var id = _postRepo.AddPost(pos);
            return id;
        }

      

        public void DeletePost(int id)
        {
            _postRepo.DeletePost(id);
        }

        public ListPostForListVm GetAllPostForList(int pageSize,int? pageNo,string searchString)
        {
            var posts = _postRepo.GetAllPosts().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<PostForListVm>(_mapper.ConfigurationProvider).ToList();
            posts.Reverse(); //odwrocenie listy zeby posty byly od najnowszego
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
