using System.Linq;
using Edu.entity;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new CourseContext();
            if(context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.School.Count()==0)
                {
                    context.School.AddRange(Schools);
                    context.Course.AddRange(Courses);
                    context.City.AddRange(Cities);
                    context.State.AddRange(States);
                    context.Country.AddRange(Countries);
                    context.Language.AddRange(Languages);
                    context.Time.AddRange(Times);
                    context.SImage.AddRange(SImages);
                    context.SaveChanges();
                    context.AddRange(CourseLanguages);
                    context.AddRange(CourseTimes);
                    context.AddRange(BranchCountries);
                    context.AddRange(BranchStates);
                    context.AddRange(BranchCities);
                    context.AddRange(BranchAccommodations);
                    context.AddRange(BranchBImages);
                    context.AddRange(SchoolSImages);
                    context.AddRange(BranchCourses);
                    context.AddRange(CountryStates);
                    context.AddRange(StateCities);
                    context.AddRange(CountryCities);
                    context.AddRange(BranchCountries);
                    context.AddRange(SchoolBranches);
                    context.SaveChanges();
                }
            }
        }
        private static Accommodation[] Accommodations={
            new Accommodation(){RoomType="Single", MealType="Only Breakfast", FacilityType="Shared", MinimumBooking=3, PricePerWeek=200, DistanceFromSchool="15-20",Active=true},
            new Accommodation(){RoomType="2 Person", MealType="Breakfast And Dinner", FacilityType="Private", MinimumBooking=1, PricePerWeek=270, DistanceFromSchool="10",Active=true},
            new Accommodation(){RoomType="3 Person", FacilityType="Shared", MinimumBooking=3, PricePerWeek=200, DistanceFromSchool="15-20",Active=true},
        };
        private static School[] Schools={
            new School(){Name="KAPLAN", Url="kaplan-okullari", LogoUrl="1.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus ullamcorper enim, at ultricies leo aliquam auctor. Donec id dapibus nibh, pellentesque pulvinar mi. Morbi non augue imperdiet, imperdiet dui et, gravida lorem. Donec quis sollicitudin dui, elementum scelerisque dui. Aliquam libero libero, commodo sit amet bibendum eget, mollis non ligula. Quisque imperdiet at orci nec vulputate. Sed vel dui vitae tellus lobortis blandit in consectetur ex. Vivamus lobortis ultricies gravida. Mauris pulvinar in dolor non dapibus. Vivamus ut dictum urna, at convallis orci. Cras eget nisi lorem.", active=true},
            new School(){Name="ASA COLLAGE", Url="ASA-okullari", LogoUrl="2.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus ullamcorper enim, at ultricies leo aliquam auctor. Donec id dapibus nibh, pellentesque pulvinar mi. Morbi non augue imperdiet, imperdiet dui et, gravida lorem. Donec quis sollicitudin dui, elementum scelerisque dui. Aliquam libero libero, commodo sit amet bibendum eget, mollis non ligula. Quisque imperdiet at orci nec vulputate. Sed vel dui vitae tellus lobortis blandit in consectetur ex. Vivamus lobortis ultricies gravida. Mauris pulvinar in dolor non dapibus. Vivamus ut dictum urna, at convallis orci. Cras eget nisi lorem.", active=true},
            new School(){Name="EUROVISAL SCHOOLS", Url="EUROVISAL-okullari", LogoUrl="3.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus ullamcorper enim, at ultricies leo aliquam auctor. Donec id dapibus nibh, pellentesque pulvinar mi. Morbi non augue imperdiet, imperdiet dui et, gravida lorem. Donec quis sollicitudin dui, elementum scelerisque dui. Aliquam libero libero, commodo sit amet bibendum eget, mollis non ligula. Quisque imperdiet at orci nec vulputate. Sed vel dui vitae tellus lobortis blandit in consectetur ex. Vivamus lobortis ultricies gravida. Mauris pulvinar in dolor non dapibus. Vivamus ut dictum urna, at convallis orci. Cras eget nisi lorem.", active=true},
            new School(){Name="BRAVE", Url="BRAVE-okullari", LogoUrl="4.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus ullamcorper enim, at ultricies leo aliquam auctor. Donec id dapibus nibh, pellentesque pulvinar mi. Morbi non augue imperdiet, imperdiet dui et, gravida lorem. Donec quis sollicitudin dui, elementum scelerisque dui. Aliquam libero libero, commodo sit amet bibendum eget, mollis non ligula. Quisque imperdiet at orci nec vulputate. Sed vel dui vitae tellus lobortis blandit in consectetur ex. Vivamus lobortis ultricies gravida. Mauris pulvinar in dolor non dapibus. Vivamus ut dictum urna, at convallis orci. Cras eget nisi lorem.", active=true},
        };
        private static Course[] Courses={
            new Course(){Name="TUUE", Url="TUUE", Discount=27.4, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=12, LessonWeek=15, HourWeek=20, MaxStudent=14, Level="Beginner", PriceCourse=700, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="RTHY", Url="RTHY", Discount=13.7, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=16, LessonWeek=10, HourWeek=15, MaxStudent=7, Level="Advanced", PriceCourse=600, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="QIES", Url="QIES", Discount=15, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=18, LessonWeek=20, HourWeek=25, MaxStudent=10, Level="Normal", PriceCourse=760, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="TMT", Url="TMT", Discount=5.9, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=21, LessonWeek=15, HourWeek=20, MaxStudent=20, Level="Advanced+", PriceCourse=650, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="UTY", Url="UTY", Discount=6.3, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=16, LessonWeek=15, HourWeek=20, MaxStudent=14, Level="Beginner+", PriceCourse=500, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="YYTRW", Url="YYTRW", Discount=10, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=21, LessonWeek=20, HourWeek=25, MaxStudent=16, Level="Beginner-", PriceCourse=550, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
            new Course(){Name="BTIEER", Url="BTIEER", Discount=19.3, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ornare a nisl sed commodo. Vivamus luctus molestie nulla eu efficitur. Phasellus rhoncus nisl id tincidunt rhoncus. Proin laoreet lorem quis tortor gravida, quis varius ligula posuere. Curabitur gravida molestie arcu, vel semper dolor dignissim ac. Donec vehicula vulputate est et ornare. Nullam non sapien turpis. Integer risus justo, tristique eu odio in, elementum placerat ipsum. Aenean odio nulla, tincidunt vitae ligula sit amet, rutrum hendrerit turpis. Integer risus lectus, luctus ac enim et, fermentum suscipit neque. Sed varius nibh in venenatis varius. Integer dictum tincidunt facilisis. Morbi imperdiet, tortor gravida venenatis porta, nunc arcu ullamcorper tellus, eu porta leo ex non quam. Integer a lacus sit amet risus varius tincidunt.", minAge=18, LessonWeek=10, HourWeek=20, MaxStudent=12, Level="Beginner", PriceCourse=625, Active=true, StartDate="01/01/2020", EndDate="01/01/2025"},
        };
        private static City[] Cities={
            new City(){Name="Istanbul", Active=true},
            new City(){Name="Berlin", Active=true},
            new City(){Name="Paris", Active=true},
            new City(){Name="Amsterdam", Active=true},
            new City(){Name="Konya", Active=true},
        };
        private static State[] States={
            new State(){Name="New York", Active=true},
            new State(){Name="California", Active=true},
            new State(){Name="Texas", Active=true},
            new State(){Name="Washington", Active=true},
        };
        private static Country[] Countries={
            new Country(){Name="USA", Active=true},
            new Country(){Name="Germany", Active=false},
            new Country(){Name="France", Active=true},
            new Country(){Name="Turkey", Active=true},
            new Country(){Name="Holland", Active=true},
        };
        private static Language[] Languages={
            new Language(){Name="Turkish"},
            new Language(){Name="English"},
            new Language(){Name="German"}
        };
        private static Time[] Times={
            new Time(){Name="Morning"},
            new Time(){Name="Afternoon"},
            new Time(){Name="Night"}
        };
        private static SImage[] SImages={
            new SImage(){Url="1.jpg"},
            new SImage(){Url="2.jpg"},
            new SImage(){Url="3.jpg"},
            new SImage(){Url="4.jpg"},
            new SImage(){Url="5.jpg"},
            new SImage(){Url="6.jpg"},
            new SImage(){Url="7.jpg"},
        };
        private static BImage[] BImages={
            new BImage(){Url="2.jpg"},
            new BImage(){Url="1.jpg"},
            new BImage(){Url="3.jpg"},
            new BImage(){Url="4.jpg"},
            new BImage(){Url="5.jpg"},
            new BImage(){Url="6.jpg"},
            new BImage(){Url="7.jpg"},
        };
        
        private static Branch[] Branches={
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30},
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30},
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30},
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30},
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30},
            new Branch(){Active = true, Discount=17, Iban="TR90 8485 7677 4368 1478", Email="Kapln@info.com", Phone="+90 548 944 84 84", Adress="4328  Mapleview Drive", PriceVisa=70, PriceHealthInsurance=30, PriceAirportPickup=30}
        };
        private static CourseLanguage[] CourseLanguages={
            new CourseLanguage(){Course=Courses[0], Language=Languages[0]},
            new CourseLanguage(){Course=Courses[1], Language=Languages[1]},
            new CourseLanguage(){Course=Courses[2], Language=Languages[2]},
            new CourseLanguage(){Course=Courses[3], Language=Languages[2]},
            new CourseLanguage(){Course=Courses[4], Language=Languages[1]},
            new CourseLanguage(){Course=Courses[5], Language=Languages[2]},
            new CourseLanguage(){Course=Courses[6], Language=Languages[1]},
        };
        private static CourseTime[] CourseTimes={
            new CourseTime(){Course=Courses[0], Time=Times[0]},
            new CourseTime(){Course=Courses[1], Time=Times[1]},
            new CourseTime(){Course=Courses[2], Time=Times[2]},
            new CourseTime(){Course=Courses[3], Time=Times[1]},
            new CourseTime(){Course=Courses[4], Time=Times[1]},
            new CourseTime(){Course=Courses[5], Time=Times[0]},
            new CourseTime(){Course=Courses[6], Time=Times[2]},
        };
        private static BranchAccommodation[] BranchAccommodations={
            new BranchAccommodation(){Branch=Branches[0], Accommodation=Accommodations[0]},
            new BranchAccommodation(){Branch=Branches[1], Accommodation=Accommodations[1]},
            new BranchAccommodation(){Branch=Branches[2], Accommodation=Accommodations[2]},
        };
        private static BranchCity[] BranchCities={
            new BranchCity(){Branch=Branches[0], City=Cities[0]},
            new BranchCity(){Branch=Branches[1], City=Cities[1]},
            new BranchCity(){Branch=Branches[2], City=Cities[2]},
            new BranchCity(){Branch=Branches[3], City=Cities[3]},
            new BranchCity(){Branch=Branches[4], City=Cities[1]},
            new BranchCity(){Branch=Branches[5], City=Cities[2]},
        };
        private static BranchCountry[] BranchCountries={
            new BranchCountry(){Branch=Branches[0], Country=Countries[0]},
            new BranchCountry(){Branch=Branches[1], Country=Countries[1]},
            new BranchCountry(){Branch=Branches[2], Country=Countries[2]},
            new BranchCountry(){Branch=Branches[3], Country=Countries[4]},
            new BranchCountry(){Branch=Branches[4], Country=Countries[2]},
            new BranchCountry(){Branch=Branches[5], Country=Countries[4]},
        };
        private static BranchCourse[] BranchCourses={
            new BranchCourse(){Branch=Branches[0], Course=Courses[0]},
            new BranchCourse(){Branch=Branches[0], Course=Courses[1]},
            new BranchCourse(){Branch=Branches[1], Course=Courses[2]},
            new BranchCourse(){Branch=Branches[1], Course=Courses[3]},
            new BranchCourse(){Branch=Branches[0], Course=Courses[4]},
            new BranchCourse(){Branch=Branches[2], Course=Courses[5]},
            new BranchCourse(){Branch=Branches[2], Course=Courses[6]},
        };
        private static SchoolSImage[] SchoolSImages={
            new SchoolSImage(){School=Schools[0], SImage=SImages[0]},
            new SchoolSImage(){School=Schools[1], SImage=SImages[1]},
            new SchoolSImage(){School=Schools[1], SImage=SImages[5]},
            new SchoolSImage(){School=Schools[2], SImage=SImages[2]},
            new SchoolSImage(){School=Schools[3], SImage=SImages[4]},
        };
        private static BranchBImage[] BranchBImages={
            new BranchBImage(){Branch=Branches[0], BImage=BImages[0]},
            new BranchBImage(){Branch=Branches[0], BImage=BImages[1]},
            new BranchBImage(){Branch=Branches[0], BImage=BImages[2]},
            new BranchBImage(){Branch=Branches[0], BImage=BImages[3]},
        };
        private static BranchState[] BranchStates={
            new BranchState(){Branch=Branches[0], State=States[0]},
            new BranchState(){Branch=Branches[1], State=States[1]},
            new BranchState(){Branch=Branches[2], State=States[2]},
            new BranchState(){Branch=Branches[3], State=States[3]},
        };
        private static CountryState[] CountryStates={
            new CountryState(){Country=Countries[0], State=States[0]},
            new CountryState(){Country=Countries[1], State=States[1]},
            new CountryState(){Country=Countries[2], State=States[2]},
            new CountryState(){Country=Countries[3], State=States[3]},
        };
        private static StateCity[] StateCities={
            new StateCity(){State=States[0], City=Cities[0]},
            new StateCity(){State=States[1], City=Cities[1]},
            new StateCity(){State=States[2], City=Cities[2]},
            new StateCity(){State=States[3], City=Cities[3]},
            new StateCity(){State=States[3], City=Cities[4]},
        };
        private static CountryCity[] CountryCities={
            new CountryCity(){Country=Countries[0], City=Cities[0]},
            new CountryCity(){Country=Countries[1], City=Cities[1]},
            new CountryCity(){Country=Countries[2], City=Cities[2]},
            new CountryCity(){Country=Countries[3], City=Cities[3]},
            new CountryCity(){Country=Countries[3], City=Cities[4]},
        };
        private static SchoolBranch[] SchoolBranches={
            new SchoolBranch(){School=Schools[0], Branch=Branches[0]},
            new SchoolBranch(){School=Schools[1], Branch=Branches[1]},
            new SchoolBranch(){School=Schools[2], Branch=Branches[2]},
            new SchoolBranch(){School=Schools[3], Branch=Branches[3]},
            new SchoolBranch(){School=Schools[3], Branch=Branches[4]},
            new SchoolBranch(){School=Schools[3], Branch=Branches[5]},
        };
    }
}