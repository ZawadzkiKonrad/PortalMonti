using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Comment;
using PortalMonti.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{   [Authorize]
    public class PostController : Controller

        
    {   private readonly IPostService _postService;
        private readonly IFriendService _friendService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, IFriendService friendService, ICommentService commentService)
        {
            _postService = postService;
            _friendService = friendService;
            _commentService = commentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.CurrentUser = _friendService.GetCurrentUser();
            ViewBag.Comments = _commentService.GetFullComment();
            
            var model = _postService.GetAllPostForList(8,1,"");
            return View(model);

        }
        [HttpPost]
        public IActionResult Index(int pageSize,int? pageNo,string searchString)
        {
            ViewBag.Comments = _commentService.GetFullComment();
            ViewBag.CurrentUser = _friendService.GetCurrentUser();

            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _postService.GetAllPostForList(pageSize,pageNo,searchString);
            return View(model);

        }

        [HttpGet]//widok z formularzem dla uzytkownika do wypelnienia
        public IActionResult AddPost()
        {
            
            return View(new NewPostVm());
        }
        // po wypenieniu formularza zwrocony odpopiedni model ktory zostanie przekazany do serwisu i nastepnie do repozytorium aby utrworzyc post
        [HttpPost]
        public async Task<ActionResult> AddPost(NewPostVm model, IFormFile file)
        {
            if (file != null)
            {
                var path = await UploadFile(file);
                model.PostImage = path;
            }

            var id = _postService.AddPost(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddComment(int postId)
        {
            return View(new NewCommentVm() 
            {
            PostId=postId
            });
        }
    
        [HttpPost]
        public IActionResult AddComment(NewCommentVm model)
        {
            
            var id = _commentService.AddComment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            var post = _postService.GetPostForEdit(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(NewPostVm model)
        {
              _postService.UpdatePost(model);
            return RedirectToAction("Index");
        }
        //na podstawie id postu pobranie z serwisu info o poscie i przekazanie jej do widoku
        public IActionResult ViewPost(int id)
        {
            //ViewBag.Comments = _commentService.GetAllComment(id);
            var postModel = _postService.GetPostById(id);
            return View(postModel);
        } 
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ShowComments(int postId)
        {
            var comments = _commentService.GetAllComment(postId);
            return PartialView("_ShowCommentsPartial", comments);
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            string pathEnd = "";
            string filename;
            bool iscopied = false;
            try
            {
                if (file.Length > 0)
                {
                    filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    iscopied = true;

                    //pathEnd = path + "\\" + filename;
                    pathEnd = filename;
                }
                else
                {
                    iscopied = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pathEnd;
        }


    }
}
