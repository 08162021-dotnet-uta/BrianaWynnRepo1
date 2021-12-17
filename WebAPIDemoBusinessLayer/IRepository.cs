using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemoBusinessLayer
{
    public interface IRepository<T,Y>
    {
        /// <summary>
        /// Creates a new record
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<T> Create(T entity);

        /// <summary>
        /// Read an existing record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Read(T entity);

        /// <summary>
        /// Read all records from the table
        /// </summary>
        /// <returns></returns>
        Task<List<T>> Read();

        /// <summary>
        /// Update a record
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Delete a record
        /// </summary>
        void Delete(T entity);
    }
}
