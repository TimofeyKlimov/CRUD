using Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EF6Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        public RepositoryBase(DbContext dbContext)
        {
            _context = dbContext;
        }
        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void RemoveEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
