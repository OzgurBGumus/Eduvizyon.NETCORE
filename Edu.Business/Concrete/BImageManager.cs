using System.Collections.Generic;
using Edu.Business.Abstract;
using Edu.data.Abstract;
using Edu.entity;

namespace Edu.Business.Concrete
{
    public class BImageManager : IBImageService
    {
        private IBImageRepository _bImageRepository;
        public BImageManager(IBImageRepository bImageRepository)
        {
            _bImageRepository = bImageRepository;
        }

        public string ErrorMessage { get; set; }

        public bool Create(BImage entity)
        {
            if(Validation(entity, false))
            {
                _bImageRepository.Create(entity);
                return true;
            }
            return false;
        }

        public bool Create(int BranchId, string name)
        {
            if(BranchId!= 0)
            {
                if(!string.IsNullOrEmpty(name))
                {
                    _bImageRepository.Create(BranchId, name);
                    return true;
                }
            }
            return false;
        }

        public bool Delete(BImage entity)
        {
            if(Validation(entity, true))
            {
                _bImageRepository.Delete(entity);
                return true;
            }
            return false;
        }

        public List<BImage> GetAll()
        {
            return _bImageRepository.GetAll();
        }

        public BImage GetById(int id)
        {
            return _bImageRepository.GetById(id);
        }

        public List<BImage> GetByIds(List<int> ids)
        {
            if(ids != null)
            {
                return _bImageRepository.GetByIds(ids);
            }
            else{
                return new List<BImage>();
            }
        }

        public BImage GetByIdWithDetails(int id)
        {
            return _bImageRepository.GetByIdWithDetails(id);
        }

        public bool Update(BImage entity)
        {
            if(Validation(entity, true))
            {
                _bImageRepository.Update(entity);
                return true;
            }
            return false;
        }

        public bool Validation(BImage entity, bool IdValidation)
        {
            bool isValid = true;
            if(IdValidation == true)
            {
                if(entity.BImageId == 0 || _bImageRepository.GetById(entity.BImageId)==null)
                {
                    ErrorMessage += "BImageId is Invalid."; isValid= false;
                }
            }
            if(string.IsNullOrEmpty(entity.Url))
            {
                ErrorMessage += "Image Url Is Empty \n";
                isValid = false;
            }
            return isValid;
        }
    }
}