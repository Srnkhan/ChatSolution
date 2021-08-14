using ChatCore.Mapper;
using ChatDb.Repository;
using ChatDb.UnitOfWork;
using ChatModals.DbModal;
using ChatModals.Dto;
using ChatServices.Abstractions;
using Modals.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServices.Implementations
{
    public class ChatImplementation : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Channel> _channelRep;
        private readonly IRepository<ChannelMessage> _channelMessage;
        public ChatImplementation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _channelRep = _unitOfWork.GetRepository<Channel>();
            _channelMessage = _unitOfWork.GetRepository<ChannelMessage>();
        }
        public ChatViewDto GetChatViewDto()
        {
            var channels = _channelRep.GetAll().Select(x => ObjectMapper.Mapper.Map<ChannelDto>(x)).ToList();
            return new ChatViewDto
            {
                ChannelList = channels
            };            
        }
        public void ChatListener(MessageDto message)
        {
            var currentChannel = _channelRep.GetAll(item => item.Id.ToString() == message.Channel).FirstOrDefault();
            var currentMessage = new Message
            {
                UserMessage = message.Message,
                UserNickName = message.Name
            };
            var currentChannelMessage = new ChannelMessage
            {
                Channel = currentChannel,
                Message = currentMessage,
            };
            _channelMessage.Add(currentChannelMessage);
            _channelRep.Add(currentChannel);
            var res = _unitOfWork.SaveChanges();
        }

        
    }
}
