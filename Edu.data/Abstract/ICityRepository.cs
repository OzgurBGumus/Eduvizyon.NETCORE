using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ICityRepository:IRepository<City>
    {
         List<City> GetByIds (List<int> ids);
         City GetCityDetails(int? id);
         bool Create(City model, int countryId, int stateId);
         bool Update(City model, int countryId, int stateId);
         bool DeleteWithSubEntities(City Model);
         List<City> GetAllWithDetails();
         List<City> GetAll();
        City GetById(int id);
        bool Delete(City entity);
    }
}