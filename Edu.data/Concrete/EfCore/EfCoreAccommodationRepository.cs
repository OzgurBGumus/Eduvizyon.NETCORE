using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreAccommodationRepository : EfCoreGenericRepository<Accommodation, CourseContext>, IAccommodationRepository
    {
        public List<Accommodation> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Accommodation> accommodations = context.Accommodation.Where(i=>i.IsDeleted==false).ToList();
                List<Accommodation> SelectedAccommodations = new List<Accommodation>();
                foreach (var accommodation in accommodations)
                {
                    if(ids.Any(i=>i==accommodation.AccommodationId))
                    {
                        SelectedAccommodations.Add(accommodation);
                    }  
                }
                return SelectedAccommodations;
            }
        }
        public List<Accommodation> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<Accommodation>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Accommodation GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<Accommodation>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Accommodation entity)
        {
            if(entity != null)
            {
                entity.IsDeleted=true;
                return Update(entity);
            }
            return false;
        }

        public bool Create(Accommodation model, int BranchId)
        {
            using(var context = new CourseContext())
            {
                Accommodation entity = model;
                Branch branch = context.Branch.Find(BranchId);
                BranchAccommodation branchAccommodation = new BranchAccommodation(){Branch=branch, Accommodation=entity};
                context.Add(branchAccommodation);
                context.SaveChanges();
                return true;
            }
        }

        public Accommodation GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.Accommodation
                                .Where(i=>i.AccommodationId==id && i.IsDeleted==false)
                                .Include(i=>i.BranchAccommodation)
                                    .ThenInclude(i=>i.Branch)
                                .FirstOrDefault();
            }
        }
    }
}