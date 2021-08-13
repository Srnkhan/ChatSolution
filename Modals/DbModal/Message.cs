using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModals.DbModal
{
    public class Message : ModalBase
    {
        public string UserNickName { get; set; }
        public string UserMessage { get; set; }

    }
}
