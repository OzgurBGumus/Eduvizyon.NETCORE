using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreBImageRepository : EfCoreGenericRepository<BImage, CourseContext>, IBImageRepository
    {
        public bool Create(int branchId, string name)
        {
            using(var context = new CourseContext())
            {
                BImage entity = new BImage(){Url=name};
                Branch branch = context.Branch.Find(branchId);
                if(branch != null)
                {
                    BranchBImage branchBImage = new BranchBImage(){Branch=branch, BImage=entity};
                    context.Add(branchBImage);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<BImage> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<BImage> bImages = context.BImage.Where(i=>i.IsDeleted==false).ToList();
                List<BImage> SelectedBImages = new List<BImage>();
                foreach (var bImage in bImages)
                {
                    if(ids.Any(i=>i==bImage.BImageId))
                    {
                        SelectedBImages.Add(bImage);
                    }  
                }
                return SelectedBImages;
            }
        }

        public BImage GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.BImage.Where(i=>i.BImageId==id && i.IsDeleted==false)
                                .Include(i=>i.BranchImage)
                                    .ThenInclude(i=>i.Branch).FirstOrDefault();
            }
        }
        public List<BImage> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<BImage>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public BImage GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<BImage>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(BImage entity)
        {
            if(entity != null)
            {
                entity.IsDeleted=true;
                return Update(entity);
            }
            return false;
        }
    }
}