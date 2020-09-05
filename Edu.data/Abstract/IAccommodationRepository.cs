using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface IAccommodationRepository:IRepository<Accommodation>
    {
        List<Accommodation> GetByIds (List<int> ids);
        List<Accommodation> GetAll();
        Accommodation GetById(int id);
        Accommodation GetByIdWithDetails(int id);
        bool Delete(Accommodation entity);
        bool Create(Accommodation model, int BranchId);
    }
}