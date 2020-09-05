using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreTimeRepository : EfCoreGenericRepository<Time, CourseContext>, ITimeRepository
    {
        public List<Time> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Time> times = context.Time.Where(i=>i.IsDeleted==false).ToList();
                List<Time> SelectedTimes = new List<Time>();
                foreach (var time in times)
                {
                    if(ids.Any(i=>i==time.TimeId))
                    {
                        SelectedTimes.Add(time);
                    }  
                }
                return SelectedTimes;
            }
        }
        public bool DeleteWithSubEntities(Time entity)
        {
            EfCoreCourseRepository courseRepository = new EfCoreCourseRepository();
            using( var context = new CourseContext())
            {
                Time time = context.Time.Where(i=>i.TimeId == entity.TimeId)
                                    .Include(i=>i.CourseTimes)
                                        .ThenInclude(i=>i.Course).FirstOrDefault();
                foreach (var courseId in time.CourseTimes.Select(i=>i.Course.CourseId))
                {
                    Course course = courseRepository.GetById(courseId);
                    courseRepository.Delete(course);
                }
                Delete(entity);
                return true;
            }
        }

        public Time GetByIdWithDetails(int id)
        {
            using(var context = new CourseContext())
            {
                return context.Time
                                .Where(i=>i.TimeId==id && i.IsDeleted == false)
                                .Include(i=>i.CourseTimes)
                                    .ThenInclude(i=>i.Course)
                                .FirstOrDefault();
            }
        }
        public List<Time> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Time.Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Time GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity = context.Set<Time>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Time entity)
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