using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatMvc.Hubs
{
    public class Chat1Hub : Hub
    {
        public override Task OnConnectedAsync()
        {
            //get conntection Id Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
     
    }
}
