using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreSchoolRepository : EfCoreGenericRepository<School, CourseContext>, ISchoolRepository
    {
        public School getSchoolDetails(int? id)
        {
            using(var context = new CourseContext())
            {
                return context.School
                                .Where(i=>i.SchoolId==id && i.IsDeleted==false)
                                .Include(i=>i.SchoolBranches)
                                    .ThenInclude(i=>i.Branch)
                                .Include(i=>i.SchoolSImages)
                                    .ThenInclude(i=>i.SImage)
                                .FirstOrDefault();
            }
        }
        public List<School> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<School> schools = context.School.Where(i=>i.IsDeleted==false).ToList();
                List<School> SelectedSchools = new List<School>();
                foreach (var school in schools)
                {
                    if(ids.Any(i=>i==school.SchoolId))
                    {
                        SelectedSchools.Add(school);
                    }  
                }
                return SelectedSchools;
            }
        }
        public bool DeleteWithSubEntities(School entity){
            EfCoreBranchRepository branchRepository = new EfCoreBranchRepository();
            EfCoreSImageRepository sImageRepository = new EfCoreSImageRepository();
            using( var context = new CourseContext())
            {
                School school = context.School.Where(i=>i.SchoolId == entity.SchoolId)
                                    .Include(i=>i.SchoolBranches)
                                        .ThenInclude(i=>i.Branch)
                                    .Include(i=>i.SchoolSImages)
                                        .ThenInclude(i=>i.SImage).FirstOrDefault();
                foreach (var sImageId in school.SchoolSImages.Select(i=>i.SImage.SImageId))
                {
                    SImage sImage = sImageRepository.GetById(sImageId);
                    sImageRepository.Delete(sImage);
                }
                foreach (var branchId in school.SchoolBranches.Select(i=>i.Branch.BranchId))
                {
                    Branch branch = branchRepository.GetById(branchId);
                    branchRepository.DeleteWithSubEntities(branch);
                }
                Delete(entity);
                return true;
            }
        }
        public List<School> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<School>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public School GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<School>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(School entity)
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