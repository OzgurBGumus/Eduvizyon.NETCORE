using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface ISImageService:IValidation<SImage>
    {
         SImage GetById(int id);
         List<SImage> GetAll();
         bool Create(SImage entity);
         bool Update(SImage entity);
         bool Delete(SImage entity);
         List<SImage> GetByIds (List<int> ids);
         bool Create(int schoolId, string name);
         SImage GetByIdWithDetails(int id);
         //bool DeleteWithKeys(int sImageId);
    }
}