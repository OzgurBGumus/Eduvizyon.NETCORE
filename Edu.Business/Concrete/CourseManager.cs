using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseRepository _courseRepository;
        private IBranchRepository _branchRepository;
        private ILanguageRepository _languageRepository;
        private ITimeRepository _timeRepository;
        public CourseManager(ICourseRepository courseRepository, IBranchRepository branchRepository, ILanguageRepository languageRepository,ITimeRepository timeRepository)
        {
            _courseRepository=courseRepository;
            _branchRepository=branchRepository;
            _languageRepository=languageRepository;
            _timeRepository=timeRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Course entity)
        {
            if(Validation(entity,false))
            {
                _courseRepository.Create(entity);
                return true;
            }
            return false;
        }
        public bool Create(Course entity, int LanguageId, int TimeId, int BranchId)
        {
            if(ValidationWithDetails(entity,LanguageId,TimeId, BranchId, false))
            {
                _courseRepository.Create(entity, LanguageId, TimeId, BranchId);
                return true;
            }
            return false;
        }
        public bool Delete(Course entity)
        {
            if(Validation(entity, true))
            {
                _courseRepository.Delete(entity);
                return true;
            }
            return false;
        }
        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
        public Course GetById(int id)
        {
            if(id > 0)
            {
                return _courseRepository.GetById(id);
            }
            return null;
        }
        public List<Course> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _courseRepository.GetByIds(ids);
            }
                return new List<Course>();
            
        }
        public Course GetCourseDetails(int id)
        {
            if(id > 0)
            {
                return _courseRepository.GetCourseDetails(id);
            }
            else return null;
            
        }
        public bool Update(Course entity)
        {
            if(Validation(entity, true))
            {
                _courseRepository.Update(entity);
                return true;
            }
            return false;
            
        }
        public bool Update(Course entity, int languageId, int timeId)
        {
            if(ValidationWithDetails(entity, languageId, timeId, true))
            {
                _courseRepository.Update(entity,languageId,timeId);
                return true;
            }
            return false;
        }
        public bool Validation(Course entity, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.CourseId == 0 || _courseRepository.GetById(entity.CourseId)==null)
                {
                    ErrorMessage += "CourseId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage +="Url is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Description))
            {
                ErrorMessage +="Description is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Level))
            {
                ErrorMessage +="Level is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.StartDate))
            {
                ErrorMessage +="StartDate is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.EndDate))
            {
                ErrorMessage +="EndDate is Invalid."; isValid= false;
            }
            return isValid;
        }
        public bool ValidationWithDetails(Course entity, int LanguageId, int TimeId, int BranchId, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.CourseId == 0 || _courseRepository.GetById(entity.CourseId)==null)
                {
                    ErrorMessage += "CourseId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage +="Url is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Description))
            {
                ErrorMessage +="Description is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Level))
            {
                ErrorMessage +="Level is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.StartDate))
            {
                ErrorMessage +="StartDate is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.EndDate))
            {
                ErrorMessage +="EndDate is Invalid."; isValid= false;
            }
            if((LanguageId !=0 && _languageRepository.GetById(LanguageId) == null) || LanguageId == 0)
            {
                ErrorMessage +="LanguageId Is Invalid"; isValid= false;
            }
            if((TimeId !=0 && _timeRepository.GetById(TimeId) == null) || TimeId == 0)
            {
                ErrorMessage +="TimeId Is Invalid"; isValid= false;
            }
            if((BranchId !=0 && _branchRepository.GetById(BranchId) == null) || BranchId==0)
            {
                ErrorMessage +="BranchId Is Invalid"; isValid= false;
            }
            System.Console.WriteLine(isValid);
            System.Console.WriteLine(ErrorMessage);
            return isValid;
        }
        public bool ValidationWithDetails(Course entity, int LanguageId, int TimeId, bool IdValidation)
        {
            bool isValid=true;
            if(IdValidation == true)
            {
                if(entity.CourseId == 0 || _courseRepository.GetById(entity.CourseId)==null)
                {
                    ErrorMessage += "CourseId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage +="Name is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage +="Url is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Description))
            {
                ErrorMessage +="Description is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.Level))
            {
                ErrorMessage +="Level is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.StartDate))
            {
                ErrorMessage +="StartDate is Invalid."; isValid= false;
            }
            if(string.IsNullOrEmpty(entity.EndDate))
            {
                ErrorMessage +="EndDate is Invalid."; isValid= false;
            }
            if(LanguageId !=0 && _languageRepository.GetById(LanguageId) == null)
            {
                ErrorMessage +="LanguageId Is Invalid"; isValid= false;
            }
            if(TimeId !=0 && _timeRepository.GetById(TimeId) == null)
            {
                ErrorMessage +="TimeId Is Invalid"; isValid= false;
            }
            return isValid;
        }
    }
}