using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{   //[Authorize]
    public class PostController : Controller

        
    {   private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //utworzyć widok dla akcji
            //tabela z postami
            //filtrowanie postów
            //przekazac filtry do serwisu
            //serwis musi przygotowac dane i zwrocic w odpowiednim formacie
            var model = _postService.GetAllPostForList(8,1,"");
            return View(model);

        }
        [HttpPost]
        public IActionResult Index(int pageSize,int? pageNo,string searchString)
        {
            if(!pageNo.HasValue)
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
        public IActionResult AddPost(NewPostVm model)
        {
            var id = _postService.AddPost(model);
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
            var postModel = _postService.GetPostById(id);
            return View(postModel);
        } 
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("Index");
        }


    }
}
