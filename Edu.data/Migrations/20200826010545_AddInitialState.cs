using Microsoft.EntityFrameworkCore.Migrations;

namespace Edu.data.Migrations
{
    public partial class AddInitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomType = table.Column<string>(nullable: true),
                    MealType = table.Column<string>(nullable: true),
                    FacilityType = table.Column<string>(nullable: true),
                    MinimumBooking = table.Column<int>(nullable: false),
                    PricePerWeek = table.Column<int>(nullable: false),
                    DistanceFromSchool = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.AccommodationId);
                });

            migrationBuilder.CreateTable(
                name: "BImage",
                columns: table => new
                {
                    BImageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BImage", x => x.BImageId);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Iban = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PriceVisa = table.Column<int>(nullable: true),
                    PriceHealthInsurance = table.Column<int>(nullable: true),
                    PriceAirportPickup = table.Column<int>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    minAge = table.Column<int>(nullable: false),
                    LessonWeek = table.Column<int>(nullable: false),
                    HourWeek = table.Column<int>(nullable: false),
                    MaxStudent = table.Column<int>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    PriceCourse = table.Column<double>(nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "SImage",
                columns: table => new
                {
                    SImageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SImage", x => x.SImageId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    TimeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.TimeId);
                });

            migrationBuilder.CreateTable(
                name: "BranchAccommodation",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    AccommodationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchAccommodation", x => new { x.BranchId, x.AccommodationId });
                    table.ForeignKey(
                        name: "FK_BranchAccommodation_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchAccommodation_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchBImage",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    BImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchBImage", x => new { x.BranchId, x.BImageId });
                    table.ForeignKey(
                        name: "FK_BranchBImage_BImage_BImageId",
                        column: x => x.BImageId,
                        principalTable: "BImage",
                        principalColumn: "BImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchBImage_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchCity",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchCity", x => new { x.BranchId, x.CityId });
                    table.ForeignKey(
                        name: "FK_BranchCity_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchCountry",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchCountry", x => new { x.BranchId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_BranchCountry_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCity",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCity", x => new { x.CountryId, x.CityId });
                    table.ForeignKey(
                        name: "FK_CountryCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCity_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchCourse",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchCourse", x => new { x.CourseId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_BranchCourse_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguage",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguage", x => new { x.CourseId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CourseLanguage_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolBranch",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolBranch", x => new { x.SchoolId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_SchoolBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolBranch_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSImage",
                columns: table => new
                {
                    SImageId = table.Column<int>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSImage", x => new { x.SchoolId, x.SImageId });
                    table.ForeignKey(
                        name: "FK_SchoolSImage_SImage_SImageId",
                        column: x => x.SImageId,
                        principalTable: "SImage",
                        principalColumn: "SImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolSImage_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchState",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchState", x => new { x.BranchId, x.StateId });
                    table.ForeignKey(
                        name: "FK_BranchState_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryState",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryState", x => new { x.CountryId, x.StateId });
                    table.ForeignKey(
                        name: "FK_CountryState_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateCity",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateCity", x => new { x.StateId, x.CityId });
                    table.ForeignKey(
                        name: "FK_StateCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateCity_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTime",
                columns: table => new
                {
                    TimeId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTime", x => new { x.CourseId, x.TimeId });
                    table.ForeignKey(
                        name: "FK_CourseTime_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTime_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchAccommodation_AccommodationId",
                table: "BranchAccommodation",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchBImage_BImageId",
                table: "BranchBImage",
                column: "BImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchCity_CityId",
                table: "BranchCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchCountry_CountryId",
                table: "BranchCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchCourse_BranchId",
                table: "BranchCourse",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchState_StateId",
                table: "BranchState",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCity_CityId",
                table: "CountryCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryState_StateId",
                table: "CountryState",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguage_LanguageId",
                table: "CourseLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTime_TimeId",
                table: "CourseTime",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolBranch_BranchId",
                table: "SchoolBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSImage_SImageId",
                table: "SchoolSImage",
                column: "SImageId");

            migrationBuilder.CreateIndex(
                name: "IX_StateCity_CityId",
                table: "StateCity",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchAccommodation");

            migrationBuilder.DropTable(
                name: "BranchBImage");

            migrationBuilder.DropTable(
                name: "BranchCity");

            migrationBuilder.DropTable(
                name: "BranchCountry");

            migrationBuilder.DropTable(
                name: "BranchCourse");

            migrationBuilder.DropTable(
                name: "BranchState");

            migrationBuilder.DropTable(
                name: "CountryCity");

            migrationBuilder.DropTable(
                name: "CountryState");

            migrationBuilder.DropTable(
                name: "CourseLanguage");

            migrationBuilder.DropTable(
                name: "CourseTime");

            migrationBuilder.DropTable(
                name: "SchoolBranch");

            migrationBuilder.DropTable(
                name: "SchoolSImage");

            migrationBuilder.DropTable(
                name: "StateCity");

            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "BImage");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "SImage");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
