using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReport.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    WorkedHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "jesper.bratt@gmail.com", "Jesper", "Bratt", "0725252" },
                    { 2, "Dejan.kulu@gmail.com", "Dejan", "Kulusevski", "7535353" },
                    { 3, "Zlatan.Zlantan.com", "Zlatan", "Ibrahimovic", "0563442" },
                    { 4, "Lewis.gb@gmail.com", "Lewis", "Hamilton", "0532523" },
                    { 5, "maxverstappen@hotmail.com", "Max", "Verstappen", "6463893" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Tågstationen Varberg" },
                    { 2, "Nya Bygget Södergatan" },
                    { 3, "Lägenhetsområade Engelbrektsgatan" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "Date", "EmployeeId", "ProjectId", "WorkedHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 8 },
                    { 2, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 8 },
                    { 3, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 8 },
                    { 4, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 12 },
                    { 5, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 6, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 8 },
                    { 7, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 6 },
                    { 8, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 8 },
                    { 12, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 6 },
                    { 9, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 8 },
                    { 10, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 8 },
                    { 11, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
