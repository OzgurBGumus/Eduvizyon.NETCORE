using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface ISImageRepository:IRepository<SImage>
    {
         List<SImage> GetByIds (List<int> ids);
         bool Create(int schoolId, string name);
         SImage GetByIdWithDetails(int id);
         List<SImage> GetAll();
        SImage GetById(int id);
        bool Delete(SImage entity);
    }
}