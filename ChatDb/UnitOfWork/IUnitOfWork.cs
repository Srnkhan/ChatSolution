using ChatDb.Repository;
using ChatModals.DbModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDb.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : ModalBase;
        int SaveChanges();
    }
}
