using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ISchoolService:IValidation<School>
    {
         School GetById(int id);
         School GetSchoolDetails(int id);
         List<School> GetAll();
         bool Create(School entity);
         bool Update(School entity);
         bool Delete(School entity);
         //void DeleteAllSchoolDetails(School model);
         List<School> GetByIds (List<int> ids);
    }
}