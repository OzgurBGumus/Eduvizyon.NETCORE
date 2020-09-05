using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ITimeRepository:IRepository<Time>
    {
         List<Time> GetByIds (List<int> ids);
         bool DeleteWithSubEntities(Time entity);
         Time GetByIdWithDetails (int id);
         List<Time> GetAll();
        Time GetById(int id);
        bool Delete(Time entity);
    }
}