using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ILanguageRepository:IRepository<Language>
    {
         List<Language> GetByIds (List<int> ids);
         bool DeleteWithSubEntities(Language entity);
         Language GetByIdWithDetails (int id);
         List<Language> GetAll();
        Language GetById(int id);
        bool Delete(Language entity);
    }
}