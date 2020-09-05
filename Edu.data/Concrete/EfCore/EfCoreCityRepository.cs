using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreCityRepository : EfCoreGenericRepository<City, CourseContext>, ICityRepository
    {
        public bool Create(City model, int countryId, int stateId)
        {
            using(var context = new CourseContext())
            {
                City entity = model;
                if(countryId != 0)
                {
                    Country country = context.Country.Find(countryId);
                    if( country != null)
                    {
                        CountryCity countryCity = new CountryCity(){Country=country, City=entity};
                        context.Add(countryCity);
                    }
                }
                if(stateId != 0)
                {
                    State state = context.State.Find(stateId);
                    if(state != null)
                    {
                        StateCity stateCity = new StateCity(){State=state, City=entity};
                        context.Add(stateCity);
                    }
                }
                if(countryId == 0 && stateId == 0)
                {
                    context.City.Add(entity);
                }
                context.SaveChanges();
                return true;
            }
        }

        public List<City> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<City> cities = context.City.Where(i=>i.IsDeleted==false).ToList();
                List<City> SelectedCities = new List<City>();
                foreach (var city in cities)
                {
                    if(ids.Any(i=>i==city.CityId))
                    {
                        SelectedCities.Add(city);
                    }  
                }
                return SelectedCities;
            }
        }

        public City GetCityDetails(int? id)
        {
            using(var context = new CourseContext())
            {
                return context.City
                                .Where(i=>i.CityId==id && i.IsDeleted==false)
                                .Include(i=>i.CountryCities)
                                    .ThenInclude(i=>i.Country)
                                .Include(i=>i.StateCities)
                                    .ThenInclude(i=>i.State)
                                .Include(i=>i.BranchCities)
                                    .ThenInclude(i=>i.Branch)
                                .FirstOrDefault();
            }
        }

        public bool Update(City model, int countryId, int stateId)
        {
            using(var context = new CourseContext())
            {
                City city = context.City
                                        .Include(i=>i.CountryCities)
                                        .Include(i=>i.StateCities)
                                        .FirstOrDefault(i=>i.CityId==model.CityId);
                if(city != null)
                {
                    city.Name=model.Name;
                    city.Active=model.Active;
                    if(countryId == 0)
                    {
                        var cmd = "delete from CountryCity where CityId=@p0";
                        context.Database.ExecuteSqlRaw(cmd,city.CityId);
                    }else{
                        Country country = context.Country.Find(countryId);
                        if(country != null)
                        {
                            city.CountryCities= new List<CountryCity>(){new CountryCity(){CountryId=(int)countryId, CityId=city.CityId}};
                        }
                    }
                    if(stateId == 0)
                    {
                        var cmd = "delete from StateCity where CityId=@p0";
                        context.Database.ExecuteSqlRaw(cmd,city.CityId);
                    }else{
                        State state = context.State.Find(stateId);
                        if(state != null)
                        {
                            city.StateCities= new List<StateCity>(){new StateCity(){StateId=(int)stateId, CityId=city.CityId}};
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteWithSubEntities(City entity)
        {
            EfCoreBranchRepository branchRepository = new EfCoreBranchRepository();
            using( var context = new CourseContext())
            {
                City city = context.City.Where(i=>i.CityId == entity.CityId)
                                    .Include(i=>i.BranchCities)
                                        .ThenInclude(i=>i.Branch).FirstOrDefault();
                foreach (var branchId in city.BranchCities.Select(i=>i.Branch.BranchId))
                {
                    Branch branch = branchRepository.GetById(branchId);
                    branchRepository.DeleteWithSubEntities(branch);
                }
                Delete(entity);
                return true;
            }
        }

        public List<City> GetAllWithDetails()
        {
            using(var context = new CourseContext())
            {
                return context.City.Where(i=>i.IsDeleted==false)
                                .Include(i=>i.CountryCities)
                                    .ThenInclude(i=>i.Country)
                                .Include(i=>i.StateCities)
                                    .ThenInclude(i=>i.State)
                                .Include(i=>i.BranchCities)
                                    .ThenInclude(i=>i.Branch)
                                .ToList();
            }
        }
        public List<City> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<City>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public City GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity =  context.Set<City>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(City entity)
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