using ChatDb.Repository;
using ChatModals.DbModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDb.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _mainDbContext;

        public EFUnitOfWork(MainDbContext context)
        {
            _mainDbContext = context;
        }

        public IRepository<T> GetRepository<T>() where T : ModalBase
        {
            return new EFRepository<T>(_mainDbContext);
        }

        public int SaveChanges()
        {
            int res = 0;
            try
            {
                res = _mainDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //ToDo
            }
            return res;
        }
    }
}
