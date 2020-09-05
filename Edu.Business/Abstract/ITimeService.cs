using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ITimeService:IValidation<Time>
    {
         Time GetById(int id);
         List<Time> GetAll();
         bool Create(Time entity);
         bool Update(Time entity);
         bool Delete(Time entity);
         List<Time> GetByIds (List<int> ids);
         Time GetByIdWithDetails (int id);
    }
}