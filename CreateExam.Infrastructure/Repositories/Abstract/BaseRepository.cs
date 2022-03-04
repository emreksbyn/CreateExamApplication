using CreateExam.Core.Entities.Interfaces;
using CreateExam.Core.Repositories.Interface.Base;
using CreateExam.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CreateExam.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected DbSet<T> table;
        public BaseRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            table = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await table.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await table.ToListAsync()
                : await table.Where(filter).ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}