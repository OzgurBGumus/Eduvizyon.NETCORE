using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        public string ErrorMessage { get; set; }
        private IBranchRepository _branchRepository;
        private ICountryRepository _countryRepository;
        private IStateRepository _stateRepository;
        private ICityRepository _cityRepository;
        private ISchoolRepository _schoolRepository;
        public BranchManager(IBranchRepository branchRepository, ICountryRepository countryRepository, IStateRepository stateRepository, ICityRepository cityRepository, ISchoolRepository schoolRepository)
        {
            _branchRepository = branchRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _schoolRepository = schoolRepository;
        }
        public bool Create(Branch entity)
        {
            if(Validation(entity, false))
            {
                _branchRepository.Create(entity);
                return true;
            }
            return false;
        }
        public bool Delete(Branch entity)
        {
            if(Validation(entity, true))
            {
                _branchRepository.DeleteWithSubEntities(entity);
                return true;
            }
            return false;
        }

        public List<Branch> GetAll()
        {
            return _branchRepository.GetAll();
        }

        public Branch GetById(int id)
        {
            if(id < 1)
            {
                ErrorMessage+="Id is Invalid(Empty).";
                return null;
            }
            return _branchRepository.GetById(id);
        }

        public List<Branch> GetByIds(List<int> ids)
        {
            if(ids == null)
            {
                ErrorMessage+="Ids is Invalid(Empty).";
                return null;
            }
            return _branchRepository.GetByIds(ids);
        }

        public Branch GetBranchDetails(int id)
        {
            if(id < 1)
            {
                ErrorMessage+="Id is Invalid(Empty).";
                return null;
            }
            return _branchRepository.GetBranchDetails(id);
        }

        public bool Update(Branch entity)
        {
            if(Validation(entity, true))
            {
                _branchRepository.Update(entity);
                return true;
            }
            return false;
        }
        public bool Create(Branch entity, int countryId, int stateId, int cityId, int schoolId)
        {
            if(ValidationWithDetails(entity, countryId, stateId, cityId, schoolId, false))
            {
                _branchRepository.Create(entity, countryId, stateId, cityId, schoolId);
                return true;
            }
            return false;
        }

        public List<Branch> GetBranchDetailsByIds(List<int> ids)
        {
            if( ids != null)
            {
                return _branchRepository.GetBranchDetailsByIds(ids);
            }
            return null;
        }

        public bool Update(Branch entity, int countryId, int stateId, int cityId)
        {
            if(ValidationWithDetails(entity, countryId,stateId,cityId,true))
            {
                return _branchRepository.Update(entity, countryId, stateId, cityId);
            }
            return false;
        }
        
        
        //VALIDATIONS
        public bool Validation(Branch entity, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.BranchId == 0 || _branchRepository.GetById(entity.BranchId)==null)
                {
                    ErrorMessage += "BranchId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Iban))
            {
                ErrorMessage +="Iban Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Email))
            {
                ErrorMessage +="Email Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Phone))
            {
                ErrorMessage +="Phone Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Adress))
            {
                ErrorMessage +="Adress Is Invalid"; isValid= false;
            }
            if(entity.PriceVisa != null)
            {
                if(entity.PriceVisa < 1 || entity.PriceVisa > 100000)
                {
                    ErrorMessage +="PriceVisa Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceHealthInsurance != null)
            {
                if(entity.PriceHealthInsurance < 1 || entity.PriceHealthInsurance > 100000)
                {
                    ErrorMessage +="PriceHealthInsurance Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceAirportPickup != null)
            {
                if(entity.PriceAirportPickup < 1 || entity.PriceAirportPickup > 100000)
                {
                    ErrorMessage +="PriceAirportPickup Is Invalid"; isValid= false;
                }
            }
            if(entity.Discount != null)
            {
                if(entity.Discount < 1 || entity.Discount > 100000)
                {
                    ErrorMessage +="Discount Is Invalid"; isValid= false;
                }
            }
            return isValid;
        }
        public bool ValidationWithDetails(Branch entity, int countryId, int stateId, int cityId, int schoolId, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.BranchId == 0 || _branchRepository.GetById(entity.BranchId)==null)
                {
                    ErrorMessage += "BranchId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Iban))
            {
                ErrorMessage +="Iban Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Email))
            {
                ErrorMessage +="Email Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Phone))
            {
                ErrorMessage +="Phone Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Adress))
            {
                ErrorMessage +="Adress Is Invalid"; isValid= false;
            }
            if(entity.PriceVisa != null)
            {
                if(entity.PriceVisa < 1 || entity.PriceVisa > 100000)
                {
                    ErrorMessage +="PriceVisa Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceHealthInsurance != null)
            {
                if(entity.PriceHealthInsurance < 1 || entity.PriceHealthInsurance > 100000)
                {
                    ErrorMessage +="PriceHealthInsurance Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceAirportPickup != null)
            {
                if(entity.PriceAirportPickup < 1 || entity.PriceAirportPickup > 100000)
                {
                    ErrorMessage +="PriceAirportPickup Is Invalid"; isValid= false;
                }
            }
            if(entity.Discount != null)
            {
                if(entity.Discount < 1 || entity.Discount > 100000)
                {
                    ErrorMessage +="Discount Is Invalid"; isValid= false;
                }
            }
            if(countryId < 1 || _countryRepository.GetById(countryId) == null)
            {
                ErrorMessage +="countryId Is Invalid"; isValid= false;
            }
            if(stateId !=0 && _stateRepository.GetById(stateId) == null)
            {
                ErrorMessage +="stateId Is Invalid"; isValid= false;
            }
            if(cityId !=0 && _cityRepository.GetById(cityId) == null)
            {
                ErrorMessage +="cityId Is Invalid"; isValid= false;
            }
            if(schoolId < 1 || _schoolRepository.GetById(schoolId) == null)
            {
                ErrorMessage +="schoolId Is Invalid"; isValid= false;
            }
            
            return isValid;
        }
        public bool ValidationWithDetails(Branch entity, int countryId, int stateId, int cityId, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.BranchId == 0 || _branchRepository.GetById(entity.BranchId)==null)
                {
                    ErrorMessage += "BranchId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Iban))
            {
                ErrorMessage +="Iban Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Email))
            {
                ErrorMessage +="Email Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Phone))
            {
                ErrorMessage +="Phone Is Invalid"; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Adress))
            {
                ErrorMessage +="Adress Is Invalid"; isValid= false;
            }
            if(entity.PriceVisa != null)
            {
                if(entity.PriceVisa < 1 || entity.PriceVisa > 100000)
                {
                    ErrorMessage +="PriceVisa Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceHealthInsurance != null)
            {
                if(entity.PriceHealthInsurance < 1 || entity.PriceHealthInsurance > 100000)
                {
                    ErrorMessage +="PriceHealthInsurance Is Invalid"; isValid= false;
                }
            }
            if(entity.PriceAirportPickup != null)
            {
                if(entity.PriceAirportPickup < 1 || entity.PriceAirportPickup > 100000)
                {
                    ErrorMessage +="PriceAirportPickup Is Invalid"; isValid= false;
                }
            }
            if(entity.Discount != null)
            {
                if(entity.Discount < 1 || entity.Discount > 100000)
                {
                    ErrorMessage +="Discount Is Invalid"; isValid= false;
                }
            }
            if(countryId == 0 || _countryRepository.GetById(countryId) == null)
            {
                ErrorMessage +="countryId Is Invalid"; isValid= false;
            }
            if(stateId !=0 && _stateRepository.GetById(stateId) == null)
            {
                ErrorMessage +="stateId Is Invalid"; isValid= false;
            }
            if(cityId !=0 && _cityRepository.GetById(cityId) == null)
            {
                ErrorMessage +="cityId Is Invalid"; isValid= false;
            }
            
            return isValid;
        }

        public List<Branch> GetAllWithDetails()
        {
            return _branchRepository.GetAllWithDetails();
        }
    }
}