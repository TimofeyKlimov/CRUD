using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);
        void RemoveEntity(T entity);
    }
}
