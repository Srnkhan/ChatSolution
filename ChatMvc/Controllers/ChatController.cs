using ChatModals.Dto;
using ChatMvc.Hubs;
using ChatServices.Abstractions;
using Microsoft.AspNetCore.Http;
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
        private readonly IRedisService _redisService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChatController(IHubContext<Chat1Hub> chatHub, IChatService chatService ,
            IRedisService redisService , IHttpContextAccessor httpContextAccessor)
        {
            _chatHub = chatHub;
            _chatService = chatService;
            _redisService = redisService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        
        {
            var chatViewDto = _chatService.GetChatViewDto();
            return View(chatViewDto);
        }

        
        [HttpPost]
        public IActionResult Message([FromBody] MessageDto message)
        {            
            _chatService.ChatListener(message);
            _chatHub.Clients.All.SendAsync("message", message);
            return Accepted();
        }
    }
}
