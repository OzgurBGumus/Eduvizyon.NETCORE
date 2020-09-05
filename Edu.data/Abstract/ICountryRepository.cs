using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ICountryRepository:IRepository<Country>
    {
         List<Country> GetByIds (List<int> ids);
         bool DeleteWithSubEntities(Country entity);
         Country GetByIdWithDetails(int id);
         List<Country> GetAll();
        Country GetById(int id);
        bool Delete(Country entity);
    }
}