using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Edu.webui.Models;
using Microsoft.AspNetCore.Mvc;
using Edu.Business.Abstract;
using Edu.entity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Edu.webui.Identity;
using Edu.webui.EmailService;
using Edu.webui.Extensions;

namespace Edu.webui.Controllers
{
    
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class AdminController:Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IAccommodationService _accommodationService;
        private ICityService _cityService;
        private ICountryService _countryService;
        private ICourseService _courseService;
        private ILanguageService _languageService;
        private ISchoolService _schoolService;
        private ISImageService _sImageService;
        private IStateService _stateService;
        private ITimeService _timeService;
        private IBranchService _branchService;
        private IBImageService _bImageService;
        private IEmailSender _emailSender;
        public AdminController(IAccommodationService accommdodationService, ICityService cityService, ICountryService countryService, ICourseService courseService, ILanguageService languageService, ISchoolService schoolService, ISImageService sImageService, IStateService stateService, ITimeService timeService, IBranchService branchService, IBImageService bImageService, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _accommodationService = accommdodationService;
            _cityService = cityService;
            _countryService = countryService;
            _courseService = courseService;
            _languageService = languageService;
            _schoolService = schoolService;
            _sImageService = sImageService;
            _stateService = stateService;
            _timeService = timeService;
            _branchService = branchService;
            _bImageService =  bImageService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
        public IActionResult SchoolList()
        {
            ViewBag.Schools = _schoolService.GetAll();
            return View();
        }
        public IActionResult BranchList()
        {
            ViewBag.Branches = _branchService.GetAllWithDetails();
            return View();
        }
        public IActionResult CourseList()
        {
            ViewBag.Courses = _courseService.GetAll();
            return View();
        }
        public IActionResult CountryList(){
            ViewBag.Countries=_countryService.GetAll();
            return View();
        }
        public IActionResult StateList(){
            ViewBag.States = _stateService.GetAllWithDetails();
            return View();
        }
        public IActionResult CityList(){
            ViewBag.Cities = _cityService.GetAllWithDetails();
            return View();
        }
        public IActionResult TimeList(){
            ViewBag.Times = _timeService.GetAll();
            return View();
        }
        public IActionResult LanguageList(){
            ViewBag.Languages = _languageService.GetAll();
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult SchoolCreate()
        {
            return View();
        }    
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public async Task<IActionResult> SchoolCreate(SchoolModel model, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(file == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Logo is not found.", AlertType="warning"});
                return View(model);
            }
            School entity = new School()
            {
                Name=model.Name,
                Url=model.Url,
                Description=model.Description,
                active=model.active,
            };
            //LOGO UPLOAD
            var extension = Path.GetExtension(file.FileName);
            var RandomName = string.Format($"{Guid.NewGuid()}{extension}");
            entity.LogoUrl=RandomName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\Logos",RandomName);
            using(var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            if(_schoolService.Create(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Created.",AlertType="success"});
                return RedirectToAction("SchoolList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_schoolService.ErrorMessage,AlertType="warning"});
            return View(model);
            
        }      
        public IActionResult SchoolEdit(int? id)
        {
            System.Console.WriteLine(id);
            if(id==null)
            {
                return RedirectToAction("SchoolList", "Admin");
            }
            School entity = _schoolService.GetSchoolDetails((int)id);
            if(entity==null)
            {
                return RedirectToAction("SchoolList", "Admin");
            }
            SchoolModel school = new SchoolModel(){
                SchoolId=entity.SchoolId,
                Name=entity.Name,
                Url=entity.Url,
                LogoUrl=entity.LogoUrl,
                Description=entity.Description,
                active=entity.active,
                SImageIds=entity.SchoolSImages.Select(i=>i.SImageId).ToList(),
                BranchIds=entity.SchoolBranches.Select(i=>i.BranchId).ToList(),
            };
            ViewBag.SImages = _sImageService.GetByIds(school.SImageIds);
            ViewBag.Branches = _branchService.GetBranchDetailsByIds(school.BranchIds);
            return View(school);
        }    
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public async Task<IActionResult> SchoolEdit(SchoolModel model, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.SImages = _sImageService.GetByIds(model.SImageIds);
                ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
                return View(model);
            }
            School entity = _schoolService.GetById(model.SchoolId);
            if(entity == null)
            {
                return NotFound();
            }
            entity.Name=model.Name;
            entity.Url=model.Url;
            entity.Description=model.Description;
            entity.active=model.active;
            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var RandomName = string.Format($"{Guid.NewGuid()}{extension}");
                entity.LogoUrl=RandomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\Logos",RandomName);
                using(var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            if(_schoolService.Update(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated.",AlertType="success"});
                return Redirect("/admin/SchoolEdit/"+model.SchoolId);
            }
            TempData.Put("message", new AlertMessage(){Message=_schoolService.ErrorMessage,AlertType="warning"});
            ViewBag.SImages = _sImageService.GetByIds(model.SImageIds);
            ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
            return View(model);
            
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult SchoolDelete(int? SchoolId)
        {
            if(SchoolId == null)
            {
                return RedirectToAction("SchoolList","Admin");
            }
            School entity = _schoolService.GetById((int)SchoolId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="School is Missing.",AlertType="danger"});
                return RedirectToAction("SchoolList","Admin");
            }
            if(_schoolService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted.",AlertType="success"});
                return RedirectToAction("SchoolList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_schoolService.ErrorMessage,AlertType="warning"});
            return RedirectToAction("SchoolList", "Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult CourseCreate(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("CourseList","Admin");
            }
            Branch entity = _branchService.GetById((int)id);
            if(entity == null)
            {
                return RedirectToAction("CourseList","Admin");
            }
            List<SelectListItem> languages = new List<SelectListItem>();
            foreach (var language in _languageService.GetAll())
            {
                languages.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
            }
            List<SelectListItem> times = new List<SelectListItem>();
            foreach (var time in _timeService.GetAll())
            {
                times.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
            }
            ViewBag.AllLanguages=languages;
            ViewBag.AllTimes=times;
            ViewBag.Branch=entity;
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CourseCreate(CourseModel model, int BranchId)
        {
            if(!ModelState.IsValid)
            {
                List<SelectListItem> languagess = new List<SelectListItem>();
                foreach (var language in _languageService.GetAll())
                {
                    languagess.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
                }
                List<SelectListItem> timess = new List<SelectListItem>();
                foreach (var time in _timeService.GetAll())
                {
                    timess.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
                }
                ViewBag.AllLanguages=languagess;
                ViewBag.AllTimes=timess;
                Branch currentBranch = _branchService.GetById((int)model.BranchId);
                ViewBag.Branch=currentBranch;
                return View(model);
            }
            Course entity = new Course()
            {
                Name=model.Name,
                Url=model.Url,
                Description=model.Description,
                minAge=(int)model.minAge,
                LessonWeek=(int)model.LessonWeek,
                HourWeek=(int)model.HourWeek,
                MaxStudent=(int)model.MaxStudent,
                Level=model.Level,
                PriceCourse=model.PriceCourse,
                Discount=model.Discount,
                Active=model.Active,
                StartDate=model.StartDate,
                EndDate=model.EndDate,
            };
            if(_courseService.Create(entity, (int)model.LanguageId, (int)model.TimeId, (int)model.BranchId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Created.",AlertType="success"});
                return Redirect("/admin/BranchEdit/"+model.BranchId);
            }
            if(entity == null)
            {
                return RedirectToAction("CourseList","Admin");
            }
            List<SelectListItem> languages = new List<SelectListItem>();
            foreach (var language in _languageService.GetAll())
            {
                languages.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
            }
            List<SelectListItem> times = new List<SelectListItem>();
            foreach (var time in _timeService.GetAll())
            {
                times.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
            }
            ViewBag.AllLanguages=languages;
            ViewBag.AllTimes=times;
            Branch currentBranchh = _branchService.GetById((int)model.BranchId);
            ViewBag.Branch=currentBranchh;
            TempData.Put("message", new AlertMessage(){Message=_courseService.ErrorMessage,AlertType="warning"});
            return View(model);
        }
        public IActionResult CourseEdit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("CourseList", "Admin");
            }
            Course courseEntity = _courseService.GetCourseDetails((int)id);
            if(courseEntity==null)
            {
                return RedirectToAction("CourseList", "Admin");
            }
            CourseModel course = new CourseModel()
            {
                CourseId=courseEntity.CourseId,
                Name = courseEntity.Name,
                Url = courseEntity.Url,
                Description = courseEntity.Description,
                minAge = courseEntity.minAge,
                LessonWeek = courseEntity.LessonWeek,
                HourWeek = courseEntity.HourWeek,
                MaxStudent = courseEntity.MaxStudent,
                Level = courseEntity.Level,
                PriceCourse = (int)courseEntity.PriceCourse,
                Discount = (int)courseEntity.Discount,
                Active = courseEntity.Active,
                StartDate = courseEntity.StartDate,
                EndDate = courseEntity.EndDate,
                LanguageId = courseEntity.CourseLanguage.Select(i=>i.LanguageId).FirstOrDefault(),
                TimeId = courseEntity.CourseTime.Select(i=>i.TimeId).FirstOrDefault(),
                BranchId = courseEntity.BranchCourse.Select(id=>id.BranchId).FirstOrDefault()
            };
            List<SelectListItem> languages = new List<SelectListItem>();
            foreach (var language in _languageService.GetAll())
            {
                languages.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
            }
            List<SelectListItem> times = new List<SelectListItem>();
            foreach (var time in _timeService.GetAll())
            {
                times.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
            }
            ViewBag.AllLanguages=languages;
            ViewBag.AllTimes=times;
            Branch currentBranch = _branchService.GetById(course.BranchId);
            ViewBag.Branch=currentBranch;
            return View(course);
        }    
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CourseEdit(CourseModel model)
        {
            if(!ModelState.IsValid)
            {
                List<SelectListItem> languages = new List<SelectListItem>();
                foreach (var language in _languageService.GetAll())
                {
                    languages.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
                }
                List<SelectListItem> times = new List<SelectListItem>();
                foreach (var time in _timeService.GetAll())
                {
                    times.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
                }
                ViewBag.AllLanguages=languages;
                ViewBag.AllTimes=times;
                Branch currentBranch = _branchService.GetById((int)model.BranchId);
                ViewBag.Branch=currentBranch;
                return View(model);
            }
            Course entity = _courseService.GetById(model.CourseId);
            if(entity == null)
            {
                return RedirectToAction("CourseList", "Admin");
            }
            entity.Name=model.Name;
            entity.Url=model.Url;
            entity.Description=model.Description;
            entity.minAge=(int)model.minAge;
            entity.LessonWeek=(int)model.LessonWeek;
            entity.HourWeek=(int)model.HourWeek;
            entity.MaxStudent=(int)model.MaxStudent;
            entity.Level=model.Level;
            entity.PriceCourse=model.PriceCourse;
            entity.Discount=model.Discount;
            entity.Active=model.Active;
            entity.StartDate=model.StartDate;
            entity.EndDate=model.EndDate;
            if(_courseService.Update(entity, (int)model.LanguageId, (int)model.TimeId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated.",AlertType="success"});
                return Redirect("/Admin/BranchEdit/"+model.BranchId);
            }
            TempData.Put("message", new AlertMessage(){Message=_courseService.ErrorMessage,AlertType="warning"});
            List<SelectListItem> languagess = new List<SelectListItem>();
            foreach (var language in _languageService.GetAll())
            {
                languagess.Add(new SelectListItem(){Text=language.Name.ToString(), Value=language.LanguageId.ToString()});
            }
            List<SelectListItem> timess = new List<SelectListItem>();
            foreach (var time in _timeService.GetAll())
            {
                timess.Add(new SelectListItem(){Text=time.Name.ToString(), Value=time.TimeId.ToString()});
            }
            ViewBag.AllLanguages=languagess;
            ViewBag.AllTimes=timess;
            Branch currentBranchh = _branchService.GetById((int)model.BranchId);
            ViewBag.Branch=currentBranchh;
            return View(model);
            
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CourseDelete(int? CourseId)
        {
            if(CourseId == null)
            {
                return RedirectToAction("CourseList","Admin");
            }
            Course entity = _courseService.GetById((int)CourseId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Course is Missing.",AlertType="danger"});
                // TempData["message"]= new AlertMessage(){
                //     Title="Failed",
                //     Message=$"School is Missing.",
                //     AlertType="warning"
                // };
                return RedirectToAction("CourseList","Admin");
            }
            if(_courseService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted.",AlertType="success"});
                return RedirectToAction("CourseList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_courseService.ErrorMessage,AlertType="danger"});
            return RedirectToAction("CourseList","Admin");
            
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public async Task<IActionResult> SImageCreate(int schoolId, IFormFile[] files)
        {
            if(files !=null)
            {
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string randomName = string.Format($"{Guid.NewGuid()}{extension}");
                    if(!_sImageService.Create(schoolId, randomName))
                    {
                        TempData.Put("message", new AlertMessage(){Message=_sImageService.ErrorMessage,AlertType="warning"});
                        return Redirect("/admin/SchoolEdit/"+schoolId);
                    }
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\SImages",randomName);
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    
                }
                TempData.Put("message", new AlertMessage(){Message=$"Resim Başarıyla Yüklendi!",AlertType="success"});
                return Redirect("/admin/SchoolEdit/"+schoolId);
            };
            TempData.Put("message", new AlertMessage(){Message=$"Dosya Bulunamadi." ,AlertType="danger"});
            return Redirect("/admin/SchoolEdit/"+schoolId);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult SImageDelete(int? sImageId)
        {   if(sImageId == null)
            {
                return RedirectToAction("SchoolList", "Admin");
            }
            SImage entity = _sImageService.GetByIdWithDetails((int)sImageId);
            int currentSchoolId = entity.SchoolSImage.Select(i=>i.School.SchoolId).FirstOrDefault();
            if(entity == null)
            {
                return RedirectToAction("SchoolList", "Admin");
            }
            if(_sImageService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message="Image is Deleted." ,AlertType="success"});
                return Redirect("/Admin/SchoolEdit/"+currentSchoolId);
            }
            TempData.Put("message", new AlertMessage(){Message=_sImageService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("SchoolList", "Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult CountryCreate()
        {
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CountryCreate(CountryModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Country entity = new Country(){
                Name=model.Name,
                Active=model.Active
            };
            if(_countryService.Create(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Name} Is Created." ,AlertType="success"});
                return RedirectToAction("CountryList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_countryService.ErrorMessage ,AlertType="warning"});
            return View(model);
            
        }
        public IActionResult CountryEdit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("CountryList", "Admin");
            }
            Country entity = _countryService.GetByIdWithDetails((int)id);
            if(entity != null)
            {
                CountryModel country = new CountryModel(){
                    CountryId = entity.CountryId,
                    Name = entity.Name,
                    Active = entity.Active,
                    BranchIds=entity.BranchCountries.Select(i=>i.BranchId).ToList(),
                };
            ViewBag.Branches = _branchService.GetBranchDetailsByIds(country.BranchIds);
            ViewBag.Cities = _cityService.GetAll();
            return View(country);
            }
            return RedirectToAction("CountryList", "Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CountryEdit(CountryModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Country entity = _countryService.GetById(model.CountryId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Okul Bulunamadi." ,AlertType="danger"});
                return RedirectToAction("CountryList", "Admin");
            }
            entity.Name=model.Name;
            entity.Active=model.Active;
            // STATE VE CITY ILE BAĞLANTI KURULDUĞUNDA UPDATE UPDATEDETAILS OLARAK DEGIS.
            if(_countryService.Update(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated." ,AlertType="success"});
                return Redirect("/admin/CountryEdit/"+model.CountryId);
            }
            TempData.Put("message", new AlertMessage(){Message=_countryService.ErrorMessage ,AlertType="warning"});
            return View(model);

            
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CountryDelete(int? countryId)
        {
            if(countryId == null)
            {
                return RedirectToAction("CountryList","Admin");
            }
            Country entity = _countryService.GetById((int)countryId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Country is Missing." ,AlertType="danger"});
                return RedirectToAction("CountryList","Admin");
            }
            //AllCountryDetails
            if(_countryService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted." ,AlertType="success"});
                return RedirectToAction("CountryList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_countryService.ErrorMessage ,AlertType="success"});
            return RedirectToAction("CountryList","Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult StateCreate()
        {
            ViewBag.Countries = _countryService.GetAll();
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult StateCreate(StateModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = _countryService.GetAll();
                return View(model);
            }
            State entity = new State(){
                Name=model.Name,
                Active=model.Active
            };
            if(_stateService.Create(entity, model.CountryId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Name} Is Created." ,AlertType="success"});
                return RedirectToAction("StateList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_stateService.ErrorMessage ,AlertType="warning"});
            ViewBag.Countries = _countryService.GetAll();
            return View(model);
            
        }
        public IActionResult StateEdit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("StateList", "Admin");
            }
            State entity = _stateService.GetStateDetails((int)id);
            if(entity==null)
            {
                return RedirectToAction("StateList", "Admin");
            }
            StateModel state = new StateModel(){
                StateId=entity.StateId,
                Name=entity.Name,
                Active=entity.Active,
                CountryId=entity.CountryStates.Select(i=>i.CountryId).FirstOrDefault(),
                CityIds=entity.StateCities.Select(i=>i.CityId).ToList(),
                BranchIds=entity.BranchStates.Select(i=>i.BranchId).ToList(),
            };
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.Branches = _branchService.GetBranchDetailsByIds(state.BranchIds);
            ViewBag.Cities = _cityService.GetAll();
            return View(state);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult StateEdit(StateModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = _countryService.GetAll();
                ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
                ViewBag.Cities = _cityService.GetAll();
                return View(model);
            }
            State entity = _stateService.GetById(model.StateId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="State is Missing." ,AlertType="warning"});
                return Redirect("Admin/CountryEdit/"+model.CountryId);
            }
            entity.Name=model.Name;
            entity.Active=model.Active;
            if(_stateService.Update(entity, model.CountryId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated." ,AlertType="success"});
                return Redirect("/admin/StateEdit/"+model.StateId);
            }
            TempData.Put("message", new AlertMessage(){Message=_stateService.ErrorMessage ,AlertType="warning"});
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
            ViewBag.Cities = _cityService.GetAll();
            return View(model);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult StateDelete(int? stateId)
        {
            if(stateId == null)
            {
                return RedirectToAction("StateList","Admin");
            }
            State entity = _stateService.GetById((int)stateId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="State is Missing." ,AlertType="danger"});
                return RedirectToAction("StateList","Admin");
            }
            if(_stateService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted." ,AlertType="success"});
                return RedirectToAction("StateList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_stateService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("StateList","Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult CityCreate()
        {
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CityCreate(CityModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = _countryService.GetAll();
                ViewBag.States = _stateService.GetAll();
                return View(model);
            }
            City entity = new City(){
                Name=model.Name,
                Active=model.Active
            };
            if(_cityService.Create(entity, model.CountryId, model.StateId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Name} Is Created." ,AlertType="success"});
                return RedirectToAction("CityList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_cityService.ErrorMessage ,AlertType="warning"});
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            return View(model);
        }
        public IActionResult CityEdit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("CityList", "Admin");
            }
            City entity = _cityService.GetCityDetails((int)id);
            if(entity==null)
            {
                TempData.Put("message", new AlertMessage(){Message="City was not found." ,AlertType="warning"});
                return RedirectToAction("CityList", "Admin");
            }
            CityModel city = new CityModel(){
                CityId=entity.CityId,
                Name=entity.Name,
                Active=entity.Active,
                CountryId=entity.CountryCities.Select(i=>i.CountryId).FirstOrDefault(),
                StateId=entity.StateCities.Select(i=>i.StateId).FirstOrDefault(),
                BranchIds=entity.BranchCities.Select(i=>i.BranchId).ToList(),
            };
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            ViewBag.Branches = _branchService.GetBranchDetailsByIds(city.BranchIds);
            return View(city);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CityEdit(CityModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = _countryService.GetAll();
                ViewBag.States = _stateService.GetAll();
                ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
                return View(model);
            }
            City entity = _cityService.GetById(model.CityId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="City is Missing." ,AlertType="warning"});
                return Redirect("Admin/CountryEdit/"+model.CountryId);
            }
            entity.Name=model.Name;
            entity.Active=model.Active;
            if(_cityService.Update(entity, model.CountryId, model.StateId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated." ,AlertType="success"});
                return Redirect("/admin/CityEdit/"+model.CityId);
            }
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            ViewBag.Branches = _branchService.GetByIds(model.BranchIds);
            return View(model);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult CityDelete(int? cityId)
        {
            if(cityId == null)
            {
                return RedirectToAction("CityList","Admin");
            }
            City entity = _cityService.GetById((int)cityId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="City is Missing." ,AlertType="danger"});
                return RedirectToAction("CityList","Admin");
            }
            if(_cityService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted." ,AlertType="success"});
                return RedirectToAction("CityList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_cityService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("CityList","Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult BranchCreate(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            School school = _schoolService.GetById((int)id);
            if(school == null)
            {
                TempData.Put("message", new AlertMessage(){Message="School Is Missing" ,AlertType="warning"});
                return RedirectToAction("BranchList", "Admin");
            }
            List<SelectListItem> countries = new List<SelectListItem>();
            foreach (var country in _countryService.GetAll())
            {
                countries.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
            }
            List<SelectListItem> states = new List<SelectListItem>();
            foreach (var state in _stateService.GetAll())
            {
                states.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
            }
            List<SelectListItem> cities = new List<SelectListItem>();
            foreach (var city in _cityService.GetAll())
            {
                cities.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
            }
            ViewBag.AllCountries=countries;
            ViewBag.AllStates=states;
            ViewBag.AllCities=cities;
            ViewBag.School=school;
            return View();
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult BranchCreate(BranchModel model)
        {
            if(!ModelState.IsValid)
            {
                School school = _schoolService.GetById(model.SchoolId);
                if(school == null)
                {
                    TempData.Put("message", new AlertMessage(){Message="School Is Missing" ,AlertType="warning"});
                    return RedirectToAction("BranchList", "Admin");
                }
                List<SelectListItem> countries = new List<SelectListItem>();
                foreach (var country in _countryService.GetAll())
                {
                    countries.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
                }
                List<SelectListItem> states = new List<SelectListItem>();
                foreach (var state in _stateService.GetAll())
                {
                    states.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
                }
                List<SelectListItem> cities = new List<SelectListItem>();
                foreach (var city in _cityService.GetAll())
                {
                    cities.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
                }
                ViewBag.AllCountries=countries;
                ViewBag.AllStates=states;
                ViewBag.AllCities=cities;
                ViewBag.School=school;
                return View(model);
            }
            Branch entity = new Branch(){
                Iban = model.Iban,
                Email = model.Email,
                Phone = model.Phone,
                Adress = model.Adress,
                PriceVisa = model.PriceVisa,
                PriceHealthInsurance = model.PriceHealthInsurance,
                PriceAirportPickup = model.PriceAirportPickup,
                Discount = model.Discount,
                Active = model.Active
            };
            if(_branchService.Create(entity, model.CountryId, model.StateId, model.CityId, model.SchoolId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Email} ({model.Phone}) Is Created." ,AlertType="success"});
                return Redirect("/admin/SchoolEdit/"+model.SchoolId);
            }
            TempData.Put("message", new AlertMessage(){Message=_branchService.ErrorMessage ,AlertType="warning"});
            School schooll = _schoolService.GetById(model.SchoolId);
            if(schooll == null)
            {
                TempData.Put("message", new AlertMessage(){Message="School Is Missing" ,AlertType="warning"});
                return RedirectToAction("BranchList", "Admin");
            }
            List<SelectListItem> countriess = new List<SelectListItem>();
            foreach (var country in _countryService.GetAll())
            {
                countriess.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
            }
            List<SelectListItem> statess = new List<SelectListItem>();
            foreach (var state in _stateService.GetAll())
            {
                statess.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
            }
            List<SelectListItem> citiess = new List<SelectListItem>();
            foreach (var city in _cityService.GetAll())
            {
                citiess.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
            }
            ViewBag.AllCountries=countriess;
            ViewBag.AllStates=statess;
            ViewBag.AllCities=citiess;
            ViewBag.School=schooll;
            return View(model);
        }
        public IActionResult BranchEdit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            Branch model = _branchService.GetBranchDetails((int)id);
            if(model == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            BranchModel branch = new BranchModel(){
                BranchId = model.BranchId,
                Iban = model.Iban,
                Email = model.Email,
                Phone = model.Phone,
                Adress = model.Adress,
                PriceVisa = model.PriceVisa,
                PriceHealthInsurance = model.PriceHealthInsurance,
                PriceAirportPickup = model.PriceAirportPickup,
                Discount = model.Discount,
                Active = model.Active,
                CountryId = model.BranchCountry.Select(i=>i.CountryId).FirstOrDefault(),
                StateId = model.BranchState.Select(i=>i.StateId).FirstOrDefault(),
                CityId = model.BranchCity.Select(i=>i.CityId).FirstOrDefault(),
                SchoolId = model.SchoolBranch.Select(i=>i.SchoolId).FirstOrDefault(),
                BImageIds = model.BranchBImage.Select(i=>i.BImageId).ToList(),
                CourseIds = model.BranchCourse.Select(i=>i.CourseId).ToList(),
                AccommodationIds = model.BranchAccommodation.Select(i=>i.AccommodationId).ToList(),
            };
            var school = _schoolService.GetById(branch.SchoolId);
            if(school != null)
            {
                ViewBag.School = _schoolService.GetById(branch.SchoolId);
            }
            ViewBag.SelectedAccommodations = _accommodationService.GetByIds(branch.AccommodationIds);
            ViewBag.SelectedBImages = _bImageService.GetByIds(branch.BImageIds);
            ViewBag.SelectedCourses = _courseService.GetByIds(branch.CourseIds);
            List<SelectListItem> countries = new List<SelectListItem>();
            foreach (var country in _countryService.GetAll())
            {
                countries.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
            }
            List<SelectListItem> states = new List<SelectListItem>();
            foreach (var state in _stateService.GetAll())
            {
                states.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
            }
            List<SelectListItem> cities = new List<SelectListItem>();
            foreach (var city in _cityService.GetAll())
            {
                cities.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
            }
            ViewBag.AllCountries=countries;
            ViewBag.AllStates=states;
            ViewBag.AllCities=cities;
            return View(branch);

        }       
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public async Task<IActionResult> BranchEdit(BranchModel model, IFormFile[] files)
        {
            if(!ModelState.IsValid)
            {
                School school = _schoolService.GetById(model.SchoolId);
                if(school == null)
                {
                    TempData.Put("message", new AlertMessage(){Message="Branch's School is Missing." ,AlertType="danger"});
                    return RedirectToAction("BranchList", "Admin");
                }
                ViewBag.School = school;
                ViewBag.SelectedAccommodations = _accommodationService.GetByIds(model.AccommodationIds);
                ViewBag.SelectedBImages = _bImageService.GetByIds(model.BImageIds);
                ViewBag.SelectedCourses = _courseService.GetByIds(model.CourseIds);
                List<SelectListItem> countries = new List<SelectListItem>();
                foreach (var country in _countryService.GetAll())
                {
                    countries.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
                }
                List<SelectListItem> states = new List<SelectListItem>();
                foreach (var state in _stateService.GetAll())
                {
                    states.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
                }
                List<SelectListItem> cities = new List<SelectListItem>();
                foreach (var city in _cityService.GetAll())
                {
                    cities.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
                }
                ViewBag.AllCountries=countries;
                ViewBag.AllStates=states;
                ViewBag.AllCities=cities;
                return View(model);
            }
            Branch entity = _branchService.GetById(model.BranchId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message=$"Branch {model.Email} is Missing." ,AlertType="warning"});
                return Redirect("Admin/SchoolEdit/"+model.SchoolId);
            }
            entity.Iban=model.Iban;
            entity.Email=model.Email;
            entity.Phone=model.Phone;
            entity.Adress=model.Adress;
            entity.PriceVisa=model.PriceVisa;
            entity.PriceHealthInsurance=model.PriceHealthInsurance;
            entity.PriceAirportPickup=model.PriceAirportPickup;
            entity.Discount=model.Discount;
            entity.Active=model.Active;
            if(_branchService.Update(entity, (int)model.CountryId, (int)model.StateId, (int)model.CityId))
            {
                if(files != null)
                {
                    foreach (var file in files)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var RandomName = string.Format($"{Guid.NewGuid()}{extension}");
                        _bImageService.Create(entity.BranchId, RandomName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\BImages",RandomName);
                        using(var stream = new FileStream(path,FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    TempData.Put("message", new AlertMessage(){Message=$"{entity.Email} ({entity.Phone}) Is Updated." ,AlertType="success"});
                    return Redirect("/admin/BranchEdit/"+model.BranchId);
                }
            }
            TempData.Put("message", new AlertMessage(){Message=_branchService.ErrorMessage ,AlertType="warning"});
            School schooll = _schoolService.GetById(model.SchoolId);
            if(schooll == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Branch's School is Missing." ,AlertType="danger"});
                return RedirectToAction("BranchList", "Admin");
            }
            ViewBag.School = schooll;
            ViewBag.SelectedAccommodations = _accommodationService.GetByIds(model.AccommodationIds);
            ViewBag.SelectedBImages = _bImageService.GetByIds(model.BImageIds);
            ViewBag.SelectedCourses = _courseService.GetByIds(model.CourseIds);
            List<SelectListItem> countriess = new List<SelectListItem>();
            foreach (var country in _countryService.GetAll())
            {
                countriess.Add(new SelectListItem(){Text=country.Name.ToString(), Value=country.CountryId.ToString()});
            }
            List<SelectListItem> statess = new List<SelectListItem>();
            foreach (var state in _stateService.GetAll())
            {
                statess.Add(new SelectListItem(){Text=state.Name.ToString(), Value=state.StateId.ToString()});
            }
            List<SelectListItem> citiess = new List<SelectListItem>();
            foreach (var city in _cityService.GetAll())
            {
                citiess.Add(new SelectListItem(){Text=city.Name.ToString(), Value=city.CityId.ToString()});
            }
            ViewBag.AllCountries=countriess;
            ViewBag.AllStates=statess;
            ViewBag.AllCities=citiess;
            return View(model);
            
            
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult BranchDelete (int? branchId)
        {
            if(branchId == null)
            {
                return RedirectToAction("BranchList","Admin");
            }
            Branch entity = _branchService.GetById((int)branchId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Branch is Missing." ,AlertType="danger"});
                return RedirectToAction("BranchList","Admin");
            }
            if(_branchService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Email}, ({entity.Phone}) Is Deleted." ,AlertType="success"});
                return RedirectToAction("BranchList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_branchService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("BranchList","Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult BImageDelete (int? bImageId)
        {   if(bImageId == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            BImage entity = _bImageService.GetByIdWithDetails((int)bImageId);
            int currentBranchId = entity.BranchImage.Select(i=>i.Branch.BranchId).FirstOrDefault();
            if(entity == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            if(_bImageService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message="Image is Deleted." ,AlertType="success"});
                return Redirect("/Admin/BranchEdit/"+currentBranchId);
            }
            TempData.Put("message", new AlertMessage(){Message=_sImageService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("BranchList", "Admin");
        }
        [Authorize(Roles=("Owner"))]
        public IActionResult TimeCreate()
        {
            return View();
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult TimeCreate(TimeModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Time entity = new Time(){
                Name=model.Name,
            };
            if(_timeService.Create(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Name} Is Created." ,AlertType="success"});
                return RedirectToAction("TimeList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_timeService.ErrorMessage ,AlertType="warning"});
            return View(model);
            
        }
        public IActionResult TimeEdit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("TimeList", "Admin");
            }
            Time entity = _timeService.GetByIdWithDetails((int)id);
            if(entity != null)
            {
                TimeModel time = new TimeModel(){
                    TimeId = entity.TimeId,
                    Name = entity.Name,
                    CourseIds=entity.CourseTimes.Select(i=>i.CourseId).ToList(),
                };
                ViewBag.Courses = _courseService.GetByIds(time.CourseIds);
                return View(time);
            }
            return RedirectToAction("TimeList", "Admin");
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult TimeEdit(TimeModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Time entity = _timeService.GetById(model.TimeId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Time Bulunamadi." ,AlertType="danger"});
                return RedirectToAction("TimeList", "Admin");
            }
            entity.Name=model.Name;
            if(_timeService.Update(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated." ,AlertType="success"});
                return Redirect("/admin/TimeEdit/"+model.TimeId);
            }
            TempData.Put("message", new AlertMessage(){Message=_timeService.ErrorMessage ,AlertType="warning"});
            return View(model);

            
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult TimeDelete(int? timeId)
        {
            if(timeId == null)
            {
                return RedirectToAction("TimeList","Admin");
            }
            Time entity = _timeService.GetById((int)timeId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Time Bulunamadi." ,AlertType="danger"});
                return RedirectToAction("TimeList","Admin");
            }
            //AllCountryDetails
            if(_timeService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted." ,AlertType="success"});
                return RedirectToAction("TimeList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_timeService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("TimeList","Admin");
        }
        [Authorize(Roles=("Owner"))]
        public IActionResult LanguageCreate()
        {
            return View();
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult LanguageCreate(LanguageModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Language entity = new Language(){
                Name=model.Name,
            };
            if(_languageService.Create(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{model.Name} Is Created." ,AlertType="success"});
                return RedirectToAction("LanguageList", "Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_languageService.ErrorMessage ,AlertType="warning"});
            return View(model);
            
        }
        public IActionResult LanguageEdit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("LanguageList", "Admin");
            }
            Language entity = _languageService.GetByIdWithDetails((int)id);
            if(entity != null)
            {
                LanguageModel language = new LanguageModel(){
                    LanguageId = entity.LanguageId,
                    Name = entity.Name,
                    CourseIds=entity.CourseLanguages.Select(i=>i.CourseId).ToList(),
                };
                ViewBag.Courses = _courseService.GetByIds(language.CourseIds);
                return View(language);
            }
            return RedirectToAction("LanguageList", "Admin");
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult LanguageEdit(LanguageModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Language entity = _languageService.GetById(model.LanguageId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Language Bulunamadi." ,AlertType="danger"});
                return RedirectToAction("LanguageList", "Admin");
            }
            entity.Name=model.Name;
            if(_languageService.Update(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Updated." ,AlertType="success"});
                return Redirect("/admin/LanguageEdit/"+model.LanguageId);
            }
            TempData.Put("message", new AlertMessage(){Message=_languageService.ErrorMessage ,AlertType="warning"});
            return View(model);

            
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public IActionResult LanguageDelete(int? languageId)
        {
            if(languageId == null)
            {
                return RedirectToAction("LanguageList","Admin");
            }
            Language entity = _languageService.GetById((int)languageId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Language is Missing." ,AlertType="danger"});
                return RedirectToAction("LanguageList","Admin");
            }
            //AllCountryDetails
            if(_languageService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"{entity.Name} Is Deleted." ,AlertType="success"});
                return RedirectToAction("LanguageList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_languageService.ErrorMessage ,AlertType="warning"});
            return RedirectToAction("LanguageList","Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        public IActionResult AccommodationCreate(int? id)
        {
            if(id != null)
            {
                Branch branch = _branchService.GetById((int)id);
                if(branch != null)
                {
                    ViewBag.Branch = branch;
                    return View();

                }
                return RedirectToAction("BranchList", "Admin");
            }
            return RedirectToAction("BranchList", "Admin");
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult AccommodationCreate(AccommodationModel model)
        {
            if(!ModelState.IsValid)
            {
                var Branchh = _branchService.GetById(model.BranchId);
                if(Branchh == null)
                {
                    return RedirectToAction("BranchList", "Admin");
                }
                ViewBag.Branch = Branchh;
                return View(model);
            }
            Accommodation entity = new Accommodation()
            {
                RoomType = model.RoomType,
                MealType = model.MealType,
                FacilityType = model.FacilityType,
                MinimumBooking = model.MinimumBooking,
                PricePerWeek = model.PricePerWeek,
                DistanceFromSchool = model.DistanceFromSchool,
                Active = model.Active
            };
            if(_accommodationService.Create(entity, model.BranchId))
            {
                TempData.Put("message", new AlertMessage(){Message=$"Accommodation is Added To the Branch.", AlertType="success"});
                return Redirect("/admin/BranchEdit/"+model.BranchId);
            }
            var Branch = _branchService.GetById(model.BranchId);
            if(Branch == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            ViewBag.Branch = Branch;
            TempData.Put("message", new AlertMessage(){Message=_accommodationService.ErrorMessage,AlertType="warning"});
            return View(model);

        }
        public IActionResult AccommodationEdit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            var accommodation = _accommodationService.GetByIdWithDetails((int)id);
            if(accommodation==null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            AccommodationModel model = new AccommodationModel()
            {
                AccommodationId = accommodation.AccommodationId,
                BranchId = accommodation.BranchAccommodation.Select(i=>i.Branch.BranchId).FirstOrDefault(),
                RoomType=accommodation.RoomType,
                MealType=accommodation.MealType,
                FacilityType=accommodation.FacilityType,
                MinimumBooking=accommodation.MinimumBooking,
                PricePerWeek=accommodation.PricePerWeek,
                DistanceFromSchool=accommodation.DistanceFromSchool,
                Active=accommodation.Active,
            };
            ViewBag.Branch = _branchService.GetById(model.BranchId);
            return View(model);
        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult AccommodationEdit(AccommodationModel model)
        {
            if(!ModelState.IsValid)
            {
                var Branch = _branchService.GetById(model.BranchId);
                if(Branch == null)
                {
                    return RedirectToAction("BranchList", "Admin");
                }
                ViewBag.Branch = Branch;
                return View(model);
            }
            Accommodation entity = _accommodationService.GetById(model.AccommodationId);
            if(entity==null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            entity.RoomType=model.RoomType;
            entity.MealType=model.MealType;
            entity.FacilityType=model.FacilityType;
            entity.MinimumBooking=model.MinimumBooking;
            entity.PricePerWeek=model.PricePerWeek;
            entity.DistanceFromSchool=model.DistanceFromSchool;
            entity.Active=model.Active;
            if(_accommodationService.Update(entity))
            {
                TempData.Put("message", new AlertMessage(){Message="Accommodation Is Updated.",AlertType="success"});
                return Redirect("/Admin/BranchEdit/"+model.BranchId);
            }
            TempData.Put("message", new AlertMessage(){Message=_accommodationService.ErrorMessage,AlertType="warning"});
            var Branchh = _branchService.GetById(model.BranchId);
            if(Branchh == null)
            {
                return RedirectToAction("BranchList", "Admin");
            }
            ViewBag.Branch = Branchh;
            return View(model);

        }
        [Authorize(Roles=("Owner, Manager"))]
        [HttpPost]
        public IActionResult AccommodationDelete(int? AccommodationId)
        {
            if(AccommodationId == null)
            {
                return RedirectToAction("BranchList","Admin");
            }
            Accommodation entity = _accommodationService.GetById((int)AccommodationId);
            if(entity == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Accommodation is Missing.",AlertType="danger"});
                return RedirectToAction("BranchList","Admin");
            }
            if(_accommodationService.Delete(entity))
            {
                TempData.Put("message", new AlertMessage(){Message=$"Selected Accommodation Is Deleted. ({entity.RoomType}, {entity.MealType}, {entity.FacilityType} , {entity.PricePerWeek})",AlertType="success"});
                return RedirectToAction("BranchList","Admin");
            }
            TempData.Put("message", new AlertMessage(){Message=_accommodationService.ErrorMessage,AlertType="danger"});
            return RedirectToAction("BranchList","Admin");
        }
        [Authorize(Roles=("Owner"))]
        public IActionResult UserRegister()
        {
            return View();
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber,
                BirthDate = model.BirthDate,
                ImageUrl = "1.png"
            };
            var result = await _userManager.CreateAsync(user, string.Format($"{Guid.NewGuid()}"));
            if(result.Succeeded)
            {
                //Here generate token and send it with mail
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Panel", new{userId=user.Id, token=code});
                await _emailSender.SendEmailAsync(model.Email,"Eduvizyon Panel", $"Eduvizyon Hesabınızı Aktive Etmek ve Şifre Almak İçin <a href='https://localhost:5001{url}'>Tıklayınız.</a>");
                TempData.Put("message", new AlertMessage(){Message="Kullanici Olusturuldu.", AlertType="success"});
                return View(new RegisterModel());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        [Authorize(Roles=("Owner"))]
        public async Task<IActionResult> UserEdit(string id){
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                UserDetailsModel model = new UserDetailsModel(){
                    UserId=user.Id,
                    UserName=user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    EmailConfirmed=user.EmailConfirmed,
                    PhoneNumber=user.PhoneNumber,
                    BirthDate=user.BirthDate,
                    Linkedin=user.Linkedin,
                    Instagram=user.Instagram,
                    Twitter=user.Twitter,
                    Description=user.Description,
                    SelectedRoles=selectedRoles
                };
                System.Console.WriteLine(model.PhoneNumber);
                ViewBag.roles = _roleManager.Roles.Select(i=>i.Name);
                return View(model);
            }
            return RedirectToAction("UserList", "Admin");
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user != null)
                {
                    user.FirstName=model.FirstName;
                    user.LastName=model.LastName;
                    user.UserName=model.UserName;
                    user.Email=model.Email;
                    user.EmailConfirmed=model.EmailConfirmed;
                    user.PhoneNumber=model.PhoneNumber;
                    var result =await _userManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        if(model.SelectedRoles == null) model.SelectedRoles = new List<string>(){};
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles.Except(userRoles));
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(model.SelectedRoles));
                        TempData.Put("message", new AlertMessage(){Message=$"User ({user.UserName}) is Updated.", AlertType="success"});
                        return Redirect("/admin/UserEdit/"+model.UserId);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.roles = _roleManager.Roles.Select(i=>i.Name);
                    return View(model);
                }
                return Redirect("/admin/UserList");
            }
            System.Console.WriteLine(model.PhoneNumber);
            ViewBag.roles = _roleManager.Roles.Select(i=>i.Name);
            return View(model);
        }
        [Authorize(Roles=("Owner"))]
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        [Authorize(Roles=("Owner"))]
        public IActionResult RoleCreate()
        {
            return View();
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _roleManager.CreateAsync(new IdentityRole(){Name=model.Name});
            if(result.Succeeded)
            {
                TempData.Put("message", new AlertMessage(){Message="Rol Oluşturuldu.", AlertType="success"});
                return RedirectToAction("RoleList", "Admin");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [Authorize(Roles=("Owner"))]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Role was not found.", AlertType="warning"});
                return RedirectToAction("RoleList","Admin");
            }
            var members = new List<User>();
            var nonMembers = new List<User>();
            //ROL SAHIBI UYELER DIGERLERINDEN AYRISTIRILIYOR.
            foreach (var user in _userManager.Users)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    members.Add(user);
                }else{
                    nonMembers.Add(user);
                }
            }
            var model = new RoleDetailModel()
            {
                Role = role,
                Members=members,
                NonMembers=nonMembers
            };
            return View(model);
        }
        [Authorize(Roles=("Owner"))]
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if(ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if(role==null)
                {
                    TempData.Put("message", new AlertMessage(){Message="Role was not found.", AlertType="warning"});
                    return RedirectToAction("RoleList","Admin");
                }
                foreach (var userId in model.IdsToAdd??new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            TempData.Put("message", new AlertMessage(){Message="Something went wrong when Adding to Role.", AlertType="success"});
                            return RedirectToAction("RoleList","Admin");
                        }
                    }
                }
                foreach (var userId in model.IdsToDelete??new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                            TempData.Put("message", new AlertMessage(){Message="Something went wrong when Removing to Role.", AlertType="success"});
                            return RedirectToAction("RoleList","Admin");
                        }
                    }
                }
                TempData.Put("message", new AlertMessage(){Message=$"Role ({model.RoleName}) is Edited.", AlertType="success"});
                return Redirect("/admin/RoleEdit/"+model.RoleId);
            }
            return View();
        }
        public async Task<IActionResult> Profile(string name)
        {
            if(User.Identity.Name == name)
            {
                if(name == null)
                {
                    return RedirectToAction("SchoolList", "Admin");
                }
                User user = await _userManager.FindByNameAsync(name);
                if(user == null)
                {
                    TempData.Put("message", new AlertMessage(){Message="User Not Found.", AlertType="warning"});
                    return RedirectToAction("SchoolList", "Admin");
                }
                UserDetailsModel model = new UserDetailsModel(){
                    UserId=user.Id,
                    UserName=user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    PhoneNumber=user.PhoneNumber,
                    ImageUrl=user.ImageUrl,
                    Linkedin=user.Linkedin,
                    Instagram=user.Instagram,
                    Twitter=user.Twitter,
                    BirthDate=user.BirthDate,
                    Description=user.Description,
                };
                ViewBag.AllRoles = _roleManager.Roles.ToList();
                return View(model);
            }
            TempData.Put("message", new AlertMessage(){Message="You Don't Have Permission For this.", AlertType="danger"});
            return RedirectToAction("SchoolList", "Admin");
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserDetailsModel model)
        {
            if(User.Identity.Name == model.UserName)
            {
                if(!ModelState.IsValid)
                {
                    ViewBag.AllRoles = _roleManager.Roles.ToList();
                    return View(model);
                }
                User user = await _userManager.FindByIdAsync(model.UserId);
                if(user == null)
                {
                    TempData.Put("message", new AlertMessage(){Message="Something Went Wrong.", AlertType="danger"});
                    return RedirectToAction("SchoolList", "Admin");
                }
                user.PhoneNumber=model.PhoneNumber;
                user.Linkedin=model.Linkedin;
                user.Instagram=model.Instagram;
                user.Twitter=model.Twitter;
                model.Description=model.Description;
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage(){Message="Account is Updated.", AlertType="success"});
                    return Redirect("/admin/Profile?Name="+model.UserName);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.AllRoles = _roleManager.Roles.ToList();
                return View(model);
            }
            TempData.Put("message", new AlertMessage(){Message="You Don't Have Permission For this.", AlertType="danger"});
            return RedirectToAction("SchoolList", "Admin");
        }
        [HttpPost]
        public async Task<IActionResult> ProfileAvatarEdit(IFormFile file, string UserId, string UserName)
        {
            if(User.Identity.Name != UserName)
            {
                TempData.Put("message", new AlertMessage(){Message="You Dont Have Permissions For this page.", AlertType="danger"});
                return RedirectToAction("SchoolList", "Admin");
            }
            if(file == null)
            {
                TempData.Put("message", new AlertMessage(){Message="File was empty", AlertType="warning"});
                return Redirect("/admin/Profile?Name="+UserName);
            }
            var user = await _userManager.FindByNameAsync(UserName);
            if(user == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Something went wrong!", AlertType="danger"});
                return RedirectToAction("SchoolList", "Admin");
            }
            string extension = Path.GetExtension(file.FileName);
            string RandomName = string.Format($"{Guid.NewGuid()}{extension}");
            user.ImageUrl=RandomName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\UserImages",RandomName);
            using(var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                TempData.Put("message", new AlertMessage(){Message="Avatar Changed!", AlertType="success"});
                return Redirect("/admin/Profile?Name="+UserName);
            }
            string errorMessage = "";
            foreach (var error in result.Errors)
            {
                errorMessage += error.Description+"/n";
                
            }
            TempData.Put("message", new AlertMessage(){Message=errorMessage, AlertType="warning"});
            return Redirect("/admin/Profile?Name="+UserName);


        }
        public async Task<IActionResult> ProfilePasswordChange(PasswordChange model){
            if(User.Identity.Name != model.UserName)
            {
                TempData.Put("message", new AlertMessage(){Message="You Dont Have Permissions For this page.", AlertType="danger"});
                return RedirectToAction("SchoolList", "Admin");
            }
            if(!ModelState.IsValid)
            {
                TempData.Put("message", new AlertMessage(){Message="Password was not updated. Old password is not correct or new password doesn't match.", AlertType="warning"});
                return Redirect("/admin/Profile?Name="+model.UserName);
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if(user == null)
            {
                TempData.Put("message", new AlertMessage(){Message="User not found.", AlertType="danger"});
                return RedirectToAction("SchoolList", "Admin");
            }
            var result = await _userManager.ChangePasswordAsync(user, model.oldPassword, model.newPassword);
            if(result.Succeeded)
            {
                TempData.Put("message", new AlertMessage(){Message="Password is updated.", AlertType="success"});
                return Redirect("/admin/Profile?Name="+model.UserName);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return Redirect("/admin/Profile?Name="+model.UserName);

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}