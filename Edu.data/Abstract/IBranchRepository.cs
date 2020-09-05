using System.Collections.Generic;
using Edu.entity;

namespace Edu.data.Abstract
{
    public interface IBranchRepository :IRepository<Branch>
    {
        Branch GetBranchDetails(int id);
        List<Branch> GetByIds (List<int> ids);
        bool Create(Branch entity, int? countryId, int? stateId, int? cityId, int SchoolId);
        List<Branch> GetBranchDetailsByIds(List<int> ids);
        bool Update(Branch entity, int countryId, int stateId, int cityId);
        bool DeleteWithSubEntities(Branch entity);
        List<Branch> GetAllWithDetails();
        List<Branch> GetAll();
        Branch GetById(int id);
        bool Delete(Branch entity);
    }
}