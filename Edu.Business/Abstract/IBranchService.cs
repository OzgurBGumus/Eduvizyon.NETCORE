using System.Collections.Generic;
using Edu.entity;

namespace Edu.Business.Abstract
{
    public interface IBranchService:IValidation<Branch>
    {
         Branch GetById(int id);
         Branch GetBranchDetails(int id);
         List<Branch> GetAll();
         List<Branch> GetAllWithDetails();
         bool Create(Branch entity);
         bool Update(Branch entity);
         bool Create(Branch entity, int countryId, int stateId, int cityId, int SchoolId);
         bool Delete(Branch entity);
         //void DeleteAllSchoolDetails(School model);
         List<Branch> GetByIds (List<int> ids);
         List<Branch> GetBranchDetailsByIds(List<int> ids);
         bool Update(Branch entity, int countryId, int stateId, int cityId);
         bool ValidationWithDetails(Branch entity, int countryId, int stateId, int cityId, int schoolId, bool IdValidation);
         bool ValidationWithDetails(Branch entity, int countryId, int stateId, int cityId, bool IdValidation);
    }
}