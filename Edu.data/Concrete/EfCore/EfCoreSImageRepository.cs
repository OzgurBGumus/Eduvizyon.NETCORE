using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreSImageRepository : EfCoreGenericRepository<SImage, CourseContext>, ISImageRepository
    {
        public List<SImage> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<SImage> sImages = context.SImage.Where(i=>i.IsDeleted==false).ToList();
                List<SImage> SelectedSImages = new List<SImage>();
                foreach (var sImage in sImages)
                {
                    if(ids.Any(i=>i==sImage.SImageId))
                    {
                        SelectedSImages.Add(sImage);
                    }  
                }
                return SelectedSImages;
            }
        }

        public bool Create(int schoolId, string name)
        {
            using(var context = new CourseContext())
            {
                SImage entity = new SImage(){Url=name};
                School school = context.School.Find(schoolId);
                if(school != null)
                {
                    SchoolSImage schoolSImage = new SchoolSImage(){School=school, SImage=entity};
                context.Add(schoolSImage);
                context.SaveChanges();
                return true;
                }
                return false;
            }
        }
        public SImage GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.SImage.Where(i=>i.SImageId==id &&i.IsDeleted==false)
                                .Include(i=>i.SchoolSImage)
                                    .ThenInclude(i=>i.School).FirstOrDefault();
            }
        }
        public List<SImage> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<SImage>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public SImage GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<SImage>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(SImage entity)
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