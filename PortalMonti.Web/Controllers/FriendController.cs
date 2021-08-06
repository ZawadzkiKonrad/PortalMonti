using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //utworzyć widok dla akcji
            //tabela z postami
            //filtrowanie postów
            //przekazac filtry do serwisu
            //serwis musi przygotowac dane i zwrocic w odpowiednim formacie
            var model = _friendService.GetAllFriends();
            return View(model);

        }
    }
}
