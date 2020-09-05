using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface IStateService:IValidation<State>
    {
         State GetById(int id);
         List<State> GetAll();
         bool Create(State entity);
         bool Update(State entity);
         bool Delete(State entity);
         List<State> GetByIds (List<int> ids);
         State GetStateDetails(int id);
        bool Update(State entity, int countryId);
        bool Create(State entity, int countryId);
        bool ValidationWithDetails(State entity, int countryId, bool IdValidation);
        List<State> GetAllWithDetails();
    }
}