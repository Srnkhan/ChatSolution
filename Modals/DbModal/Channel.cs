using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModals.DbModal
{
    public class Channel : ModalBase
    {
        public string ChannelName { get; set; }

        public ICollection<ChannelMessage> ChannelMessages { get; set; }

    }
}
