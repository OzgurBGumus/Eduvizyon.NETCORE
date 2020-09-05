using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Edu.Business.Abstract;
using Edu.Business.Concrete;
using Edu.data.Abstract;
using Edu.data.Concrete.EfCore;
using Edu.webui.EmailService;
using Edu.webui.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Edu.webui
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options=>{options.UseSqlite("Data Source=CourseDb");});
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options=>{
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.AllowedForNewUsers = true;
                //User
                options.User.RequireUniqueEmail=true;
                //Sign
                options.SignIn.RequireConfirmedEmail = true;
            });
            services.ConfigureApplicationCookie(options=>{
                options.LoginPath = "/panel/login";
                options.LogoutPath = "/panel/logout";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder(){
                    Name = "Eduvizyon.Panel.Security.Cookie",
                    HttpOnly=true,
                    SameSite=SameSiteMode.Strict
                };
            });

            services.AddScoped<IEmailSender, SmtpEmailSender>(i=>
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"]
                    ));
            //PROVIDERS
            services.AddScoped<IAccommodationRepository, EfCoreAccommodationRepository>();
            services.AddScoped<ICityRepository, EfCoreCityRepository>();
            services.AddScoped<ICountryRepository, EfCoreCountryRepository>();
            services.AddScoped<ICourseRepository, EfCoreCourseRepository>();
            services.AddScoped<ILanguageRepository, EfCoreLanguageRepository>();
            services.AddScoped<ISchoolRepository, EfCoreSchoolRepository>();
            services.AddScoped<ISImageRepository, EfCoreSImageRepository>();
            services.AddScoped<IStateRepository, EfCoreStateRepository>();
            services.AddScoped<ITimeRepository, EfCoreTimeRepository>();
            services.AddScoped<IBranchRepository, EfCoreBranchRepository>();
            services.AddScoped<IBImageRepository, EfCoreBImageRepository>();
            
            //SERVICES
            services.AddScoped<IAccommodationService, AccommodationManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ISchoolService, SchoolManager>();
            services.AddScoped<ISImageService, SImageManager>();
            services.AddScoped<IStateService, StateManager>();
            services.AddScoped<ITimeService, TimeManager>();
            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<IBImageService, BImageManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath="/modules"
            });

            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //School Endpoints
                endpoints.MapControllerRoute(
                    name:"adminSchoolDelete",
                    pattern:"admin/schools/delete",
                    defaults: new {controller="Admin", action="SchoolDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminSchoolCreate",
                    pattern:"admin/schools/create",
                    defaults: new {controller="Admin", action="SchoolCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminSchoolEdit",
                    pattern:"admin/schools/{id}",
                    defaults: new {controller="Admin", action="SchoolEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminSchoolList",
                    pattern:"admin/schools",
                    defaults: new {controller="Admin", action="SchoolList"}
                );
                //Branch Endpoints
                endpoints.MapControllerRoute(
                    name:"adminBranchDelete",
                    pattern:"admin/branches/delete",
                    defaults: new {controller="Admin", action="BranchDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminBranchCreate",
                    pattern:"admin/branches/create/{id}",
                    defaults: new {controller="Admin", action="BranchCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminBranchEdit",
                    pattern:"admin/branches/{id}",
                    defaults: new {controller="Admin", action="BranchEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminBranchList",
                    pattern:"admin/branches",
                    defaults: new {controller="Admin", action="BranchList"}
                );
                //Course Endpoints
                endpoints.MapControllerRoute(
                    name:"adminCourseDelete",
                    pattern:"admin/courses/delete/",
                    defaults: new {controller="Admin", action="CourseDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCourseCreate",
                    pattern:"admin/courses/create",
                    defaults: new {controller="Admin", action="CourseCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCourseEdit",
                    pattern:"admin/courses/{id}",
                    defaults: new {controller="Admin", action="CourseEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCourseList",
                    pattern:"admin/courses",
                    defaults: new {controller="Admin", action="CourseList"}
                );
                //SIMAGE, BIMAGE Delete, Create POST oldugu icin endpoint eklemedim.
                //Country Endpoints
                endpoints.MapControllerRoute(
                    name:"adminCountryDelete",
                    pattern:"admin/countries/delete",
                    defaults: new {controller="Admin", action="CountryDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCountryCreate",
                    pattern:"admin/countries/create",
                    defaults: new {controller="Admin", action="CountryCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCountryEdit",
                    pattern:"admin/countries/{id}",
                    defaults: new {controller="Admin", action="CountryEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCountryList",
                    pattern:"admin/countries",
                    defaults: new {controller="Admin", action="CountryList"}
                );
                //State Endpoints
                endpoints.MapControllerRoute(
                    name:"adminStateDelete",
                    pattern:"admin/states/delete",
                    defaults: new {controller="Admin", action="StateDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminStateCreate",
                    pattern:"admin/states/create",
                    defaults: new {controller="Admin", action="StateCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminStateEdit",
                    pattern:"admin/states/{id}",
                    defaults: new {controller="Admin", action="StateEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminStateList",
                    pattern:"admin/states",
                    defaults: new {controller="Admin", action="StateList"}
                );
                //City Endpoints
                endpoints.MapControllerRoute(
                    name:"adminCityDelete",
                    pattern:"admin/cities/delete",
                    defaults: new {controller="Admin", action="CityDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCityCreate",
                    pattern:"admin/cities/create",
                    defaults: new {controller="Admin", action="CityCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCityEdit",
                    pattern:"admin/cities/{id}",
                    defaults: new {controller="Admin", action="CityEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminCityList",
                    pattern:"admin/cities",
                    defaults: new {controller="Admin", action="CityList"}
                );
                //Time Endpoints
                endpoints.MapControllerRoute(
                    name:"adminTimeDelete",
                    pattern:"admin/times/delete",
                    defaults: new {controller="Admin", action="TimeDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminTimeCreate",
                    pattern:"admin/times/create",
                    defaults: new {controller="Admin", action="TimeCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminTimeEdit",
                    pattern:"admin/times/{id}",
                    defaults: new {controller="Admin", action="TimeEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminTimeList",
                    pattern:"admin/times",
                    defaults: new {controller="Admin", action="TimeList"}
                );
                //Language Endpoints
                endpoints.MapControllerRoute(
                    name:"adminLanguageDelete",
                    pattern:"admin/languages/delete",
                    defaults: new {controller="Admin", action="LanguageDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminLanguageCreate",
                    pattern:"admin/languages/create",
                    defaults: new {controller="Admin", action="LanguageCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminLanguageEdit",
                    pattern:"admin/languages/{id}",
                    defaults: new {controller="Admin", action="LanguageEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminLanguageList",
                    pattern:"admin/languages",
                    defaults: new {controller="Admin", action="LanguageList"}
                );
                //Accommodation Endpoints
                endpoints.MapControllerRoute(
                    name:"adminAccommodationDelete",
                    pattern:"admin/accommodations/delete",
                    defaults: new {controller="Admin", action="AccommodationDelete"}
                );
                endpoints.MapControllerRoute(
                    name:"adminAccommodationCreate",
                    pattern:"admin/accommodations/create",
                    defaults: new {controller="Admin", action="AccommodationCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminAccommodationEdit",
                    pattern:"admin/accommodations/{id}",
                    defaults: new {controller="Admin", action="AccommodationEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminAccommodationList",
                    pattern:"admin/accommodations",
                    defaults: new {controller="Admin", action="AccommodationList"}
                );
                //User Endpoints
                // endpoints.MapControllerRoute(
                //     name:"adminUserDelete",
                //     pattern:"admin/users/delete",
                //     defaults: new {controller="Admin", action="CountryDelete"}
                // );
                endpoints.MapControllerRoute(
                    name:"adminUserRegister",
                    pattern:"admin/users/register",
                    defaults: new {controller="Admin", action="UserRegister"}
                );
                endpoints.MapControllerRoute(
                    name:"adminUserEdit",
                    pattern:"admin/users/{id}",
                    defaults: new {controller="Admin", action="UserEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminUserList",
                    pattern:"admin/users",
                    defaults: new {controller="Admin", action="UserList"}
                );
                //Role Endpoints
                // endpoints.MapControllerRoute(
                //     name:"adminUserDelete",
                //     pattern:"admin/users/delete",
                //     defaults: new {controller="Admin", action="CountryDelete"}
                // );
                endpoints.MapControllerRoute(
                    name:"adminRoleCreate",
                    pattern:"admin/roles/register",
                    defaults: new {controller="Admin", action="RoleCreate"}
                );
                endpoints.MapControllerRoute(
                    name:"adminRoleEdit",
                    pattern:"admin/roles/{id}",
                    defaults: new {controller="Admin", action="UserEdit"}
                );
                endpoints.MapControllerRoute(
                    name:"adminRoleList",
                    pattern:"admin/roles",
                    defaults: new {controller="Admin", action="RoleList"}
                );
                //
                endpoints.MapControllerRoute(
                    name:"adminSchoolList",
                    pattern:"admin/schools",
                    defaults: new {controller="Admin", action="SchoolList"}
                );
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Admin}/{action=SchoolList}/{id?}"
                );
            });
            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
        }
    }
}
