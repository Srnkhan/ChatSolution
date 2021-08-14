using AutoMapper;
using ChatModals.DbModal;
using ChatModals.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatCore.Mapper
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Channel, ChannelDto>();

            // All other mappings goes here
        }
    }
}
