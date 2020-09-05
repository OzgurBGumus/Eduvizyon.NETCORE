using System.Collections.Generic;

namespace Edu.data.Abstract
{
    public interface IRepository<T>
    {
         bool Create(T entity);
         bool Update(T entity);
         
    }
}