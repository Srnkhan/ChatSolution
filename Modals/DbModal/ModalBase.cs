using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModals.DbModal
{
    public class ModalBase
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
