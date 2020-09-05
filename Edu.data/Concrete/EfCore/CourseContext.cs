using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class CourseContext:DbContext
    {
        public DbSet<School> School { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<SImage> SImage { get; set; }
        public DbSet<BImage> BImage { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Time> Time { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CourseDb");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<CourseLanguage>().HasKey(c=>new{c.CourseId, c.LanguageId});
            modelbuilder.Entity<CourseTime>().HasKey(c=>new{c.CourseId, c.TimeId});
            modelbuilder.Entity<BranchAccommodation>().HasKey(c=>new{c.BranchId, c.AccommodationId});
            modelbuilder.Entity<BranchCity>().HasKey(c=>new{c.BranchId, c.CityId});
            modelbuilder.Entity<BranchCountry>().HasKey(c=>new{c.BranchId, c.CountryId});
            modelbuilder.Entity<BranchCourse>().HasKey(c=>new{c.CourseId, c.BranchId});
            modelbuilder.Entity<SchoolSImage>().HasKey(c=>new{c.SchoolId, c.SImageId});
            modelbuilder.Entity<BranchState>().HasKey(c=>new{c.BranchId, c.StateId});
            modelbuilder.Entity<BranchBImage>().HasKey(c=>new{c.BranchId, c.BImageId});
            modelbuilder.Entity<CountryState>().HasKey(c=>new{c.CountryId, c.StateId});
            modelbuilder.Entity<StateCity>().HasKey(c=>new{c.StateId, c.CityId});
            modelbuilder.Entity<CountryCity>().HasKey(c=>new{c.CountryId, c.CityId});
            modelbuilder.Entity<SchoolBranch>().HasKey(c=>new{c.SchoolId, c.BranchId});
        }
    }
    
}