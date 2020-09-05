using System.Collections.Generic;
using System.Linq;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{

    public class AccommodationManager : IAccommodationService
    {
        private IAccommodationRepository _accommodationRepository;
        private IBranchRepository _branchRepository;
        public AccommodationManager(IAccommodationRepository AccommodationRepository, IBranchRepository BranchRepository)
        {
            _accommodationRepository=AccommodationRepository;
            _branchRepository=BranchRepository;
        }

        public string ErrorMessage { get; set;}

        public bool Create(Accommodation entity)
        {
            if(Validation(entity, false))
            {
                _accommodationRepository.Create(entity);
                return true;
            }
            return false;
            
        }

        public bool Create(Accommodation entity, int BranchId)
        {
            if(Validation(entity, BranchId, false))
            {
                _accommodationRepository.Create(entity, BranchId);
                return true;
            }
            return false;
        }

        public bool Delete(Accommodation entity)
        {
            if(Validation(entity, true))
            {
                _accommodationRepository.Delete(entity);
                return true;
            }
            return false;
            
        }

        public List<Accommodation> GetAll()
        {
            return _accommodationRepository.GetAll();
        }

        public Accommodation GetById(int id)
        {
            if(id > 0)
            {
                return _accommodationRepository.GetById(id);
            }
            return null;
            
        }

        public List<Accommodation> GetByIds(List<int> ids)
        {
            if(ids != null || !ids.Any(i=>i<1))
            {
                return _accommodationRepository.GetByIds(ids);
            }
                return new List<Accommodation>();
        }

        public Accommodation GetByIdWithDetails(int id)
        {
            if(id > 0)
            {
                return _accommodationRepository.GetByIdWithDetails(id);
            }
            return null;
        }

        public bool Update(Accommodation entity)
        {
            if(Validation(entity, true))
            {
                _accommodationRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Validation(Accommodation entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.AccommodationId == 0 || _accommodationRepository.GetById(entity.AccommodationId)==null)
                {
                    ErrorMessage += "AccommodationId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.RoomType))
            {
                ErrorMessage +="RoomType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.MealType))
            {
                ErrorMessage +="MealType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.FacilityType))
            {
                ErrorMessage +="FacilityType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.DistanceFromSchool))
            {
                ErrorMessage +="DistanceFromSchool is Invalid."; isValid= false;
            }
            if(entity.MinimumBooking < 0 || entity.MinimumBooking> 1000)
            {
                ErrorMessage +="PriceVisa Is Invalid"; isValid= false;
            }
            if(entity.PricePerWeek < 0 || entity.PricePerWeek> 100000)
            {
                ErrorMessage +="PricePerWeek Is Invalid"; isValid= false;
            }
            return isValid;
        }
        public bool Validation(Accommodation entity, int BranchId, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.AccommodationId == 0 || _accommodationRepository.GetById(entity.AccommodationId)==null)
                {
                    ErrorMessage += "AccommodationId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.RoomType))
            {
                ErrorMessage +="RoomType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.MealType))
            {
                ErrorMessage +="MealType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.FacilityType))
            {
                ErrorMessage +="FacilityType is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.DistanceFromSchool))
            {
                ErrorMessage +="DistanceFromSchool is Invalid."; isValid= false;
            }
            if(entity.MinimumBooking < 0 || entity.MinimumBooking> 1000)
            {
                ErrorMessage +="PriceVisa Is Invalid"; isValid= false;
            }
            if(entity.PricePerWeek < 0 || entity.PricePerWeek> 100000)
            {
                ErrorMessage +="PricePerWeek Is Invalid"; isValid= false;
            }
            if((BranchId !=0 && _branchRepository.GetById(BranchId) == null) || BranchId==0)
            {
                ErrorMessage +="BranchId Is Invalid"; isValid= false;
            }
            return isValid;
        }
    }
}