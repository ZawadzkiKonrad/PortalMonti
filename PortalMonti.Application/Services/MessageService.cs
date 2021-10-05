using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Message;
using PortalMonti.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MessageService(  IMessageRepository postRepo, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _messageRepo = postRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }
        public int SendMessage(NewMessageVm message)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var msg = _mapper.Map<Domain.Model.ReceivedMessage>(message);
            msg.Date = DateTime.Now;
            msg.Author = userId;
            msg.AppUserId = message.Receiver;

            var id = _messageRepo.SendMessage(msg);
            return id;
        }
        public IQueryable<MessageForListVm> GetAllMessages()
        {
            var messages = _messageRepo.GetAllMessages().ProjectTo<MessageForListVm>(_mapper.ConfigurationProvider);
            return messages;
        }

        public MessageDetailsVm GetMessageById(int id)
        {
            var message = _messageRepo.GetMessageById(id);
            var messageVm = _mapper.Map<MessageDetailsVm>(message);
            return messageVm;
            
            
        }
    }
}
