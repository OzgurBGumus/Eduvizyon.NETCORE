using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ISchoolRepository:IRepository<School>
    {
        School getSchoolDetails(int? id);
        List<School> GetByIds (List<int> ids);
        bool DeleteWithSubEntities(School entity);
        List<School> GetAll();
        School GetById(int id);
        bool Delete(School entity);
    }
}