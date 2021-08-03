using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    public class PostController : Controller

        
    {   private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            //utworzyć widok dla akcji
            //tabela z postami
            //filtrowanie postów
            //przekazac filtry do serwisu
            //serwis musi przygotowac dane i zwrocic w odpowiednim formacie
            var model = _postService.GetAllPostForList();
            return View(model);

        }
        [HttpGet]//widok z formularzem dla uzytkownika do wypelnienia
        public IActionResult AddPost()
        {
            return View();
        }
        //[HttpPost] po wypenieniu formularza zwrocony odpopiedni model ktory zostanie przekazany do serwisu i nastepnie do repozytorium aby utrworzyc post
        //public IActionResult AddPost(PostModel model)
        //{
        //    var id = _postService.AddPost(model);
        //    return View();
        //} 
                //na podstawie id postu pobranie z serwisu info o poscie i przekazanie jej do widoku
        public IActionResult ViewPost(int postId)
        {
            var postModel = _postService.GetPostById(postId);
            return View(postModel);
        }


    }
}
