using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreCourseRepository : EfCoreGenericRepository<Course, CourseContext>, ICourseRepository
    {
        public bool Create(Course model, int LanguageId, int TimeId, int BranchId)
        {
            using(var context = new CourseContext())
            {
                Course entity = model;
                Time time = context.Time.Find(TimeId);
                Language language = context.Language.Find(LanguageId);
                Branch branch = context.Branch.Find(BranchId);
                CourseTime courseTime = new CourseTime(){Course=entity, Time=time};
                CourseLanguage courseLanguage = new CourseLanguage(){Course=entity, Language=language};
                BranchCourse branchCourse = new BranchCourse(){Branch=branch, Course=entity};
                context.Add(courseTime);
                context.Add(courseLanguage);
                context.Add(branchCourse);
                context.SaveChanges();
                return true;
            }
        }
        public Course GetCourseDetails(int? id)
        {
            using(var context = new CourseContext())
            {
                return context.Course
                                .Where(i=>i.CourseId==id && i.IsDeleted==false)
                                .Include(i=>i.CourseLanguage)
                                    .ThenInclude(i=>i.Language)
                                .Include(i=>i.CourseTime)
                                    .ThenInclude(i=>i.Time)
                                .Include(i=>i.BranchCourse)
                                    .ThenInclude(i=>i.Branch)
                                .FirstOrDefault();
            }
        }
        public bool Update(Course entity, int languageId, int timeId)
        {
            using(var context = new CourseContext())
            {
                Course course = context.Course
                                        .Include(i=>i.BranchCourse)
                                        .Include(i=>i.CourseLanguage)
                                        .Include(i=>i.CourseTime)
                                        .FirstOrDefault(i=>i.CourseId==entity.CourseId);
                if(course != null)
                {
                    course.Name=entity.Name;
                    course.Url=entity.Url;
                    course.Description=entity.Description;
                    course.minAge=entity.minAge;
                    course.LessonWeek=entity.LessonWeek;
                    course.HourWeek=entity.HourWeek;
                    course.MaxStudent=entity.MaxStudent;
                    course.Level=entity.Level;
                    course.PriceCourse=entity.PriceCourse;
                    course.Discount=entity.Discount;
                    course.Active=entity.Active;
                    course.StartDate=entity.StartDate;
                    course.EndDate=entity.EndDate;
                    course.CourseLanguage= new List<CourseLanguage>(){new CourseLanguage(){CourseId=course.CourseId, LanguageId=languageId}};
                    course.CourseTime= new List<CourseTime>(){new CourseTime(){CourseId=course.CourseId, TimeId=timeId}};
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<Course> GetByIds(List<int> ids)
        {
            using(var context = new CourseContext())
            {
                List<Course> courses = context.Course.Where(i=>i.IsDeleted==false).ToList();
                List<Course> SelectedCourses = new List<Course>();
                foreach (var course in courses)
                {
                    if(ids.Any(i=>i==course.CourseId))
                    {
                        SelectedCourses.Add(course);
                    }  
                }
                return SelectedCourses;
            }
        }
        public List<Course> GetAll()
        {
            using(var context = new CourseContext())
            {
                return context.Set<Course>().Where(i=>i.IsDeleted==false).ToList();
            }
        }

        public Course GetById(int id)
        {
            using(var context = new CourseContext())
            {
                var entity =  context.Set<Course>().Find(id);
                if(entity != null && entity.IsDeleted == false) return entity;
                else return null;
            }
        }

        public bool Delete(Course entity)
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