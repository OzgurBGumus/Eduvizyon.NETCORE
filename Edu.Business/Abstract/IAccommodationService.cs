using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface IAccommodationService:IValidation<Accommodation>
    {
         Accommodation GetById(int id);
         List<Accommodation> GetAll();
         bool Create(Accommodation entity);
         bool Update(Accommodation entity);
         bool Delete(Accommodation entity);
         List<Accommodation> GetByIds (List<int> ids);
         bool Create(Accommodation entity, int BranchId);
         Accommodation GetByIdWithDetails(int id);
         bool Validation(Accommodation entity, int BranchId, bool IdValidation);
    }
}