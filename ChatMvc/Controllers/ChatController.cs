using ChatMvc.Hubs;
using ChatServices.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Modals.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatMvc.Controllers
{
    public class ChatController : Controller
    {
        private readonly IHubContext<Chat1Hub> _chatHub;
        private readonly IChatService _chatService;
        public ChatController(IHubContext<Chat1Hub> chatHub, IChatService chatService)
        {
            _chatHub = chatHub;
            _chatService = chatService;
        }
        public IActionResult Index()
        {
            var chatViewDto = _chatService.GetChatViewDto();
            return View(chatViewDto);
        }

        
        [HttpPost]
        public IActionResult Message([FromBody] MessageDto message)
        {
            //same bussines rules
            _chatService.ChatListener(message);
            _chatHub.Clients.All.SendAsync("message", message);

            return Accepted();
        }
    }
}
