using ChatModals.Dto;
using Modals.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServices.Abstractions
{
    public interface IChatService
    {
        public ChatViewDto GetChatViewDto();
        public void ChatListener(MessageDto message);
    }
}
