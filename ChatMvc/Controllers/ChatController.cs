using ChatMvc.Hubs;
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
        public ChatController(IHubContext<Chat1Hub> chatHub)
        {
            _chatHub = chatHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Message([FromBody] MessageDto order)
        {
            //same bussines rules
            _chatHub.Clients.All.SendAsync("message", order);

            return Accepted();
        }
    }
}
