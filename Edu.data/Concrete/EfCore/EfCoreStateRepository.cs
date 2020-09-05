using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreStateRepository : EfCoreGenericRepository<State, CourseContext>, IStateRepository
    {
        public bool Create(State model, int countryId)
        {
            using(var context = new CourseContext())
            {
                State entity = model;
                Country country = context.Country.Find(countryId);
                if(country == null) return false;
                CountryState countryState = new CountryState(){Country=country, State=entity};
                context.Add(countryState);
                context.SaveChanges();
                return true;
            }
        }

        public List<State> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<State> states = context.State.Where(i=>i.IsDeleted==false).ToList();
                List<State> SelectedStates = new List<State>();
                foreach (var state in states)
                {
                    if(ids.Any(i=>i==state.StateId))
                    {
                        SelectedStates.Add(state);
                    }  
                }
                return SelectedStates;
            }
        }

        public State GetStateDetails(int? id)
        {
            using(var context = new CourseContext())
            {
                return context.State
                                .Where(i=>i.StateId==id && i.IsDeleted==false)
                                .Include(i=>i.StateCities)
                                    .ThenInclude(i=>i.City)
                                .Include(i=>i.CountryStates)
                                    .ThenInclude(i=>i.Country)
                                .Include(i=>i.BranchStates)
                                    .ThenInclude(i=>i.Branch)
                                .FirstOrDefault();
            }
        }

        public bool UpdateDetails(State entity, int? countryId)
        {
            using(var context = new CourseContext())
            {
                if(countryId == null)
                {
                    return false;
                }
                State state = context.State
                                        .Include(i=>i.CountryStates)
                                        .FirstOrDefault(i=>i.StateId==entity.StateId);
                if(state != null)
                {
                    state.Name=entity.Name;
                    state.Active=entity.Active;
                    state.CountryStates= new List<CountryState>(){new CountryState(){CountryId=(int)countryId, StateId=state.StateId}};
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteWithSubEntities(State entity)
        {
            EfCoreBranchRepository branchRepository = new EfCoreBranchRepository();
            EfCoreCityRepository cityRepository = new EfCoreCityRepository();
            using( var context = new CourseContext())
            {
                State state = context.State.Where(i=>i.StateId == entity.StateId)
                                    .Include(i=>i.BranchStates)
                                        .ThenInclude(i=>i.Branch)
                                    .Include(i=>i.StateCities)
                                        .ThenInclude(i=>i.City).FirstOrDefault();
                foreach (var branchId in state.BranchStates.Select(i=>i.Branch.BranchId))
                {
                    Branch branch = branchRepository.GetById(branchId);
                    branchRepository.DeleteWithSubEntities(branch);
                }
                foreach (var cityId in state.StateCities.Select(i=>i.City.CityId))
                {
                    City city = cityRepository.GetById(cityId);
                    cityRepository.DeleteWithSubEntities(city);
                }
                Delete(entity);
                return true;
            }
        }

        public List<State> GetAllWithDetails()
        {
            using(var context = new CourseContext())
            {
                return context.State.Where(i=>i.IsDeleted==false)
                                .Include(i=>i.StateCities)
                                    .ThenInclude(i=>i.City)
                                .Include(i=>i.CountryStates)
                                    .ThenInclude(i=>i.Country)
                                .Include(i=>i.BranchStates)
                                    .ThenInclude(i=>i.Branch)
                                .ToList();
            }
        }
        public List<State> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<State>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public State GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<State>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(State entity)
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