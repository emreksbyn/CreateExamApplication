using CreateExam.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CreateExam.Core.Repositories.Interface.Base
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
    }
}