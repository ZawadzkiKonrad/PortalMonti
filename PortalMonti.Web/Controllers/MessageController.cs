using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Message;
using PortalMonti.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IFriendService _friendService;
        public MessageController(IMessageService messageService, IFriendService friendService)
        {
            _messageService=messageService;
            _friendService = friendService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Friends = _friendService.GetAllFriends();

            var model = _messageService.GetAllMessages();
            return View(model);

        }
        public IActionResult ViewMessage(int id)
        {
            var messageModel = _messageService.GetMessageById(id);
                
            return View(messageModel);
        }


        [HttpGet]//widok z formularzem dla uzytkownika do wypelnienia
        public IActionResult SendMessage()
        {
            ViewBag.Friends = _friendService.GetAllFriends();
            return View(new NewMessageVm());
        }
        // po wypenieniu formularza zwrocony odpopiedni model ktory zostanie przekazany do serwisu i nastepnie do repozytorium aby utrworzyc post


        [HttpPost]
        public IActionResult SendMessage(NewMessageVm model)
        {
            var id = _messageService.SendMessage(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SendMessageToFriend(string appUserId,IFormCollection form)
        {
           //string strDDLValue = form["messages"].ToString();

            ViewBag.Friends = _friendService.GetAllFriends();
            return View(new NewMessageVm()
            {Receiver=appUserId,
            AppUserId=appUserId}
            );
        }
        [HttpPost]
        public IActionResult SendMessageToFriend(NewMessageVm model, IFormCollection form)
        
        {
           // string strDDLValue = form["messages"].ToString();

            ViewBag.Friends = _friendService.GetAllFriends();
            var id = _messageService.SendMessage(model);
            return RedirectToAction("Index");
        }
    }
}
