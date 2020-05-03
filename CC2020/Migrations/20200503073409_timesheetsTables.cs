using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CC2020.Migrations
{
    public partial class timesheetsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ABN = table.Column<long>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ABN);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    TFN = table.Column<string>(maxLength: 9, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 40, nullable: true),
                    State = table.Column<string>(maxLength: 3, nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "PayAgreements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaturdayRate = table.Column<double>(nullable: false),
                    SundayRate = table.Column<double>(nullable: false),
                    PublicHolidayRate = table.Column<double>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayAgreements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayAgreements_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ABN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayAgreements_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Break = table.Column<TimeSpan>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Timesheets_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ABN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timesheets_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayAgreements_CompanyID",
                table: "PayAgreements",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PayAgreements_EmployeeID",
                table: "PayAgreements",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_CompanyID",
                table: "Timesheets",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeID",
                table: "Timesheets",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayAgreements");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
