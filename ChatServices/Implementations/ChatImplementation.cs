using ChatCore.Mapper;
using ChatDb.Repository;
using ChatDb.UnitOfWork;
using ChatModals.DbModal;
using ChatModals.Dto;
using ChatServices.Abstractions;
using Microsoft.AspNetCore.Http;
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
        private readonly IRedisService _redisService;
        private readonly IRepository<Channel> _channelRep;
        private readonly IRepository<ChannelMessage> _channelMessage;
        private readonly IRepository<Message> _messageRep;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatImplementation(IUnitOfWork unitOfWork , IRedisService redisService , IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _channelRep = _unitOfWork.GetRepository<Channel>();
            _channelMessage = _unitOfWork.GetRepository<ChannelMessage>();
            _messageRep = _unitOfWork.GetRepository<Message>();
            _redisService = redisService;
            _httpContextAccessor = httpContextAccessor;
        }
        public ChatViewDto GetChatViewDto()
        {
            var currentChannels = _redisService.PopKey<ChatViewDto>("ChatViewDto");
            var viewDto = new ChatViewDto();
            if(currentChannels == null)
            {                
                var chatviewDto  = _channelRep.GetAll().Select(x => ObjectMapper.Mapper.Map<ChannelDto>(x)).ToList();
                viewDto.ChannelList = chatviewDto;
                _redisService.SetKey<ChatViewDto>("ChatViewDto", viewDto);
            }
            else
            {
                viewDto = currentChannels;
            }
            return viewDto;
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
            _messageRep.Add(currentMessage);
            _unitOfWork.SaveChanges();
        }
       
        
    }
}
