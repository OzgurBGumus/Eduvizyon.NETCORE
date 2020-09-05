using System.Collections.Generic;
using Edu.entity;
namespace Edu.data.Abstract
{
    public interface ICourseRepository:IRepository<Course>
    {
        Course GetCourseDetails(int? id);
        bool Create(Course model, int LanguageId, int TimeId, int BranchId);
        bool Update(Course entity, int LanguageId, int TimeId);
        //void DeleteAllCourseDetails(Course entity);
        List<Course> GetByIds (List<int> ids);
        List<Course> GetAll();
        Course GetById(int id);
        bool Delete(Course entity);
    }
}