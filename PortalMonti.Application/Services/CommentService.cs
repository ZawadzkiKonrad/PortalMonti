using AutoMapper;
using AutoMapper.QueryableExtensions;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Comment;
using PortalMonti.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentService(ICommentRepository commentRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public int AddComment(NewCommentVm comment)

        {
            var commentNew = _mapper.Map<Domain.Model.Comment>(comment);
            commentNew.Author= _httpContextAccessor.HttpContext.User.Identity.Name;
            var data = DateTime.Today.ToString().Remove(10,9); //usuwanie godziny z daty
            commentNew.Date = data;
            var id= _commentRepo.AddComment(commentNew);
            return id;
        }

        public IQueryable<CommentVm> GetAllComment(int postId)
        {
            var comments = _commentRepo.GetAllComments(postId).ProjectTo<CommentVm>(_mapper.ConfigurationProvider);
            
            
            return comments;
        }
    }
}
