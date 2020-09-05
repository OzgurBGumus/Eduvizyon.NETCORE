using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreCountryRepository : EfCoreGenericRepository<Country, CourseContext>, ICountryRepository
    {
        public List<Country> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Country> countries = context.Country.Where(i=>i.IsDeleted==false).ToList();
                List<Country> SelectedCountries = new List<Country>();
                foreach (var country in countries)
                {
                    if(ids.Any(i=>i==country.CountryId))
                    {
                        SelectedCountries.Add(country);
                    }  
                }
                return SelectedCountries;
            }
        }
        public bool DeleteWithSubEntities(Country entity)
        {
            EfCoreBranchRepository branchRepository = new EfCoreBranchRepository();
            EfCoreCityRepository cityRepository = new EfCoreCityRepository();
            EfCoreStateRepository stateRepository = new EfCoreStateRepository();
            using( var context = new CourseContext())
            {
                Country country = context.Country.Where(i=>i.CountryId == entity.CountryId)
                                    .Include(i=>i.CountryStates)
                                        .ThenInclude(i=>i.State)
                                    .Include(i=>i.CountryCities)
                                        .ThenInclude(i=>i.City)
                                    .Include(i=>i.BranchCountries)
                                        .ThenInclude(i=>i.Branch).FirstOrDefault();
                foreach (var branchId in country.BranchCountries.Select(i=>i.Branch.BranchId))
                {
                    Branch branch = branchRepository.GetById(branchId);
                    branchRepository.DeleteWithSubEntities(branch);
                }
                foreach (var cityId in country.CountryCities.Select(i=>i.City.CityId))
                {
                    City city = cityRepository.GetById(cityId);
                    cityRepository.DeleteWithSubEntities(city);
                }
                foreach (var stateId in country.CountryStates.Select(i=>i.State.StateId))
                {
                    State state = stateRepository.GetById(stateId);
                    stateRepository.DeleteWithSubEntities(state);
                }
                Delete(entity);
                return true;
            }
        }

        public Country GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.Country
                                .Where(i=>i.CountryId==id && i.IsDeleted==false)
                                .Include(i=>i.BranchCountries)
                                    .ThenInclude(i=>i.Branch)
                                .FirstOrDefault();
            }
        }
        public List<Country> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<Country>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Country GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<Country>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Country entity)
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