using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ICityService:IValidation<City>
    {
         City GetById(int id);
         List<City> GetAll();
         bool Create(City entity);
         bool Update(City entity);
         bool Delete(City entity);
         List<City> GetByIds (List<int> ids);
         City GetCityDetails(int id);
         bool Create(City entity, int countryId, int stateId);
         bool Update(City entity, int countryId, int stateId);
         bool ValidationWithDetails(City entity, int countryId, int stateId, bool IdValidation);
         List<City> GetAllWithDetails();
    }
}