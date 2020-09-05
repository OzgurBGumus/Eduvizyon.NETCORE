using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface IStateRepository:IRepository<State>
    {
         List<State> GetByIds (List<int> ids);
         State GetStateDetails(int? id);
         bool UpdateDetails(State entity, int? countryId);
         bool Create(State model, int countryId);
         bool DeleteWithSubEntities(State entity);
         List<State> GetAllWithDetails();
         List<State> GetAll();
        State GetById(int id);
        bool Delete(State entity);
    }
}