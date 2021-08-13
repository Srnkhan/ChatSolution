using ChatModals.DbModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatDb.Repository
{
    public interface IRepository<T> where T : ModalBase
    {
        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns></returns>
        IQueryable GetAll();

        /// <summary>
        /// Get All Data with Predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Func<T, bool> predicate);

        /// <summary>
        /// Get All Data By Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Get Data By predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Func<T, bool> predicate);

        /// <summary>
        /// Add Data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete Data to SelectedProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete Data to id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        void Delete(Guid id);
    }
}
