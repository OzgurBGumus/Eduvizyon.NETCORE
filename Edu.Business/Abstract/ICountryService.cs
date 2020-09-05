using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ICountryService:IValidation<Country>
    {
         Country GetById(int id);
         List<Country> GetAll();
         bool Create(Country entity);
         bool Update(Country entity);
         bool Delete(Country entity);
         List<Country> GetByIds (List<int> ids);
         Country GetByIdWithDetails(int id);
    }
}