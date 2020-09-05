using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface IBImageService :IValidation<BImage>
    {
         BImage GetById(int id);
         List<BImage> GetAll();
         bool Create(BImage entity);
         bool Update(BImage entity);
         bool Delete(BImage entity);
         List<BImage> GetByIds (List<int> ids);
         bool Create(int schoolId, string name);
         BImage GetByIdWithDetails(int id);
    }
}