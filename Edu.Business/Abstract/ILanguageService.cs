using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ILanguageService:IValidation<Language>
    {
         Language GetById(int id);
         List<Language> GetAll();
         bool Create(Language entity);
         bool Update(Language entity);
         bool Delete(Language entity);
         List<Language> GetByIds (List<int> ids);
         Language GetByIdWithDetails (int id);
    }
}