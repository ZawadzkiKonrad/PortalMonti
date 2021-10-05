using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IMessageRepository _messageRepo;
        public MessageController(IMessageService messageService, IFriendService friendService, IMessageRepository messageRepo)
        {
            _messageService=messageService;
            _friendService = friendService;
            _messageRepo = messageRepo;
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
            
            var conversation=_messageRepo.GetConveration(appUserId);
            ViewBag.Conversation = conversation;
            //string strDDLValue = form["messages"].ToString();
            var friends = _friendService.GetAllFriends();
            List<string>friendsId= new List<string>();
            foreach (var item in friends)
            {
                friendsId.Add(item.Name);
            }
            
            return View(new NewMessageVm()
            {//Receiver=appUserId,
            AppUserId=appUserId
            }
            );
        }
        [HttpPost]
        public IActionResult SendMessageToFriend(NewMessageVm model, IFormCollection form)
        
        {
            // string strDDLValue = form["messages"].ToString();

            var conversation = _messageRepo.GetConveration(model.Receiver);
            ViewBag.Convesation = conversation;
            var appUserId = model.AppUserId;
            
            var friends = _friendService.GetAllFriends();
            List<string> friendsId = new List<string>();
            foreach (var item in friends)
            {
                friendsId.Add(item.Name);
            }
            
            var id = _messageService.SendMessage(model);
            return View(new NewMessageVm()
            {
                
                
                
            }
           );
        }
    }
}
