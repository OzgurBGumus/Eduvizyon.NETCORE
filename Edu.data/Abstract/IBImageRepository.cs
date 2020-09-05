using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface IBImageRepository : IRepository<BImage>
    {
         List<BImage> GetByIds (List<int> ids);
         bool Create(int branchId, string name);
         BImage GetByIdWithDetails(int id);
         List<BImage> GetAll();
        BImage GetById(int id);
        bool Delete(BImage entity);
    }
}