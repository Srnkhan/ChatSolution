using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModals.DbModal
{
    public class ChannelMessage : ModalBase
    {
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }

        public Guid MessageId { get; set; }
        public Message Message { get; set; }
    }
}
