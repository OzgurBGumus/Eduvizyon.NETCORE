using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreBranchRepository : EfCoreGenericRepository<Branch, CourseContext>, IBranchRepository
    {
        public bool Create(Branch entity, int? countryId, int? stateId, int? cityId, int SchoolId)
        {
            using(var context = new CourseContext())
            {
                Branch branch = entity;
                if(countryId !=  null)
                {
                    Country country = context.Country.Find(countryId);
                    if( country != null)
                    {
                        BranchCountry branchCountry = new BranchCountry(){Branch=branch, Country=country};
                        context.Add(branchCountry);
                    }
                }
                if(stateId != null)
                {
                    State state = context.State.Find(stateId);
                    if(state != null)
                    {
                        BranchState branchState = new BranchState(){Branch=branch, State=state};
                        context.Add(branchState);
                    }
                }
                if(cityId != null)
                {
                    City city = context.City.Find(cityId);
                    if(city != null)
                    {
                        BranchCity branchCity = new BranchCity(){Branch=branch, City=city};
                        context.Add(branchCity);
                    }
                }
                School school = context.School.Find(SchoolId);
                if(school != null)
                {
                    SchoolBranch schoolBranch = new SchoolBranch(){School=school, Branch=branch};
                    context.Add(schoolBranch);
                }
                context.SaveChanges();
                return true;
            }
        }

        public Branch GetBranchDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.Branch
                                .Where(i=>i.BranchId==id && i.IsDeleted==false)
                                    .Include(i=>i.BranchCountry)
                                        .ThenInclude(i=>i.Country)
                                    .Include(i=>i.BranchState)
                                        .ThenInclude(i=>i.State)
                                    .Include(i=>i.BranchCity)
                                        .ThenInclude(i=>i.City)
                                    .Include(i=>i.BranchCourse)
                                        .ThenInclude(i=>i.Course)
                                    .Include(i=>i.BranchAccommodation)
                                        .ThenInclude(i=>i.Accommodation)
                                    .Include(i=>i.BranchBImage)
                                        .ThenInclude(i=>i.BImage)
                                    .Include(i=>i.SchoolBranch)
                                        .ThenInclude(i=>i.School)
                                    .FirstOrDefault();
            }
        }
        public bool DeleteWithSubEntities(Branch entity){
            EfCoreCourseRepository courseRepository = new EfCoreCourseRepository();
            EfCoreBImageRepository bImageRepository = new EfCoreBImageRepository();
            using( var context = new CourseContext())
            {
                Branch branch = context.Branch.Where(i=>i.BranchId == entity.BranchId)
                                    .Include(i=>i.BranchCourse)
                                        .ThenInclude(i=>i.Course)
                                    .Include(i=>i.BranchBImage)
                                        .ThenInclude(i=>i.BImage).FirstOrDefault();
                foreach (var courseId in branch.BranchCourse.Select(i=>i.Course.CourseId))
                {
                    Course course = courseRepository.GetById(courseId);
                    courseRepository.Delete(course);
                }
                foreach (var bImageId in branch.BranchBImage.Select(i=>i.BImage.BImageId))
                {
                    BImage bImage = bImageRepository.GetById(bImageId);
                    bImageRepository.Delete(bImage);
                }
                Delete(entity);
                return true;
            }
        }
        public List<Branch> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                //List<Branch> branches = context.Branch.ToList();
                List<Branch> SelectedBranches = context.Branch.Where(i=>ids.Any(id=> i.BranchId ==id) && i.IsDeleted==false).ToList();
                // foreach (var branch in branches)
                // {
                //     if(ids.Any(i=>i==branch.BranchId))
                //     {
                //         SelectedBranches.Add(school);
                //     }  
                // }
                return SelectedBranches;
            }
        }
        public List<Branch> GetBranchDetailsByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Branch> SelectedBranches = context.Branch.Where(i=>ids.Any(id=> i.BranchId ==id) && i.IsDeleted==false)
                                            .Include(i=>i.BranchCountry)
                                                .ThenInclude(i=>i.Country)
                                            .Include(i=>i.BranchState)
                                                .ThenInclude(i=>i.State)
                                            .Include(i=>i.BranchCity)
                                                .ThenInclude(i=>i.City)
                                            .Include(i=>i.BranchCourse)
                                                .ThenInclude(i=>i.Course)
                                            .Include(i=>i.BranchAccommodation)
                                                .ThenInclude(i=>i.Accommodation)
                                            .Include(i=>i.BranchBImage)
                                                .ThenInclude(i=>i.BImage)
                                            .Include(i=>i.SchoolBranch)
                                                .ThenInclude(i=>i.School)
                                            .ToList();
                return SelectedBranches;
            }
        }
        public bool Update(Branch entity, int countryId, int stateId, int cityId)
        {
            using(var context = new CourseContext())
            {
                Branch branch = context.Branch
                                        .Include(i=>i.BranchCountry)
                                        .Include(i=>i.BranchState)
                                        .Include(i=>i.BranchCity)
                                        .FirstOrDefault(i=>i.BranchId==entity.BranchId);
                if(branch != null)
                {
                    branch.Iban=entity.Iban;
                    branch.Email=entity.Email;
                    branch.Phone=entity.Phone;
                    branch.Adress=entity.Adress;
                    branch.PriceVisa=entity.PriceVisa;
                    branch.PriceHealthInsurance=entity.PriceHealthInsurance;
                    branch.PriceAirportPickup=entity.PriceAirportPickup;
                    branch.Discount=entity.Discount;
                    branch.Active=entity.Active;
                    Country country = context.Country.Find(countryId);
                    if(country != null)
                    {
                        branch.BranchCountry= new List<BranchCountry>(){new BranchCountry(){BranchId=branch.BranchId, CountryId=countryId}};
                    }
                    if(stateId == 0)
                    {
                        var cmd = "delete from BranchState where BranchId=@p0";
                        context.Database.ExecuteSqlRaw(cmd,branch.BranchId);
                    }else{
                        State state = context.State.Find(stateId);
                        if(state != null)
                        {
                            branch.BranchState= new List<BranchState>(){new BranchState(){BranchId=branch.BranchId, StateId=state.StateId}};
                        }
                    }
                    if(cityId == 0)
                    {
                        var cmd = "delete from BranchCity where BranchId=@p0";
                        context.Database.ExecuteSqlRaw(cmd,branch.BranchId);
                    }else{
                        City city = context.City.Find(cityId);
                        if(city != null)
                        {
                            branch.BranchCity= new List<BranchCity>(){new BranchCity(){BranchId=branch.BranchId, CityId=city.CityId}};
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Branch> GetAllWithDetails()
        {
            using(var context = new CourseContext())
            {
                List<Branch> SelectedBranches = context.Branch.Where(i=>i.IsDeleted==false)
                                            .Include(i=>i.BranchCountry)
                                                .ThenInclude(i=>i.Country)
                                            .Include(i=>i.BranchState)
                                                .ThenInclude(i=>i.State)
                                            .Include(i=>i.BranchCity)
                                                .ThenInclude(i=>i.City)
                                            .Include(i=>i.BranchCourse)
                                                .ThenInclude(i=>i.Course)
                                            .Include(i=>i.BranchAccommodation)
                                                .ThenInclude(i=>i.Accommodation)
                                            .Include(i=>i.BranchBImage)
                                                .ThenInclude(i=>i.BImage)
                                            .Include(i=>i.SchoolBranch)
                                                .ThenInclude(i=>i.School)
                                            .ToList();
                return SelectedBranches;
            }
        }
        public List<Branch> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<Branch>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Branch GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity =  context.Set<Branch>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Branch entity)
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