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
using Microsoft.AspNetCore.Identity;
using PortalMonti.Domain.Model;

namespace PortalMonti.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentService(ICommentRepository commentRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public int AddComment(NewCommentVm comment)

        {
            var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            var commentNew = _mapper.Map<Domain.Model.Comment>(comment);
            commentNew.ProfileImage = user.ImageProfile;
            commentNew.Author = user.Email;
            //commentNew.AuthorId
            commentNew.AuthorId = user.Id;
            var data = DateTime.Today.ToString().Remove(10,9); //usuwanie godziny z daty
            commentNew.Date = DateTime.Now.ToString();

            var id= _commentRepo.AddComment(commentNew);
            return id;
        }

        public IQueryable<CommentVm> GetAllComment(int postId)
        {
            var comments = _commentRepo.GetAllComments(postId).ProjectTo<CommentVm>(_mapper.ConfigurationProvider);
            
            
            return comments;
        }

        public IQueryable<CommentVm> GetFullComment()
        {   var comments = _commentRepo.GetFullComment().ProjectTo<CommentVm>(_mapper.ConfigurationProvider);
            return comments;
        }
    }
}
