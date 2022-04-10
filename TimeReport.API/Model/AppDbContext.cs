using Microsoft.EntityFrameworkCore;
using System;

namespace TimeReport.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee
            modelBuilder.Entity<Employee>().HasData(new Employee { 
                EmployeeId = 1, 
                FirstName = "Jesper", 
                LastName = "Bratt", 
                PhoneNumber = "0725252", 
                Email = "jesper.bratt@gmail.com"});
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Dejan",
                LastName = "Kulusevski",
                PhoneNumber = "7535353",
                Email = "Dejan.kulu@gmail.com"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Zlatan",
                LastName = "Ibrahimovic",
                PhoneNumber = "0563442",
                Email = "Zlatan.Zlantan.com"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Lewis",
                LastName = "Hamilton",
                PhoneNumber = "0532523",
                Email = "Lewis.gb@gmail.com"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                FirstName = "Max",
                LastName = "Verstappen",
                PhoneNumber = "6463893",
                Email = "maxverstappen@hotmail.com"
            });

            // Seed project
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 1, ProjectName = "Tågstationen Varberg" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 2, ProjectName = "Nya Bygget Södergatan" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 3, ProjectName = "Lägenhetsområade Engelbrektsgatan" });

            // Seed time reports
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { 
                TimeReportId = 1, 
                EmployeeId = 1, 
                ProjectId = 1, 
                Date = new DateTime(2022, 04, 10), 
                WorkedHours = 8 });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { 
                TimeReportId = 2, 
                EmployeeId = 2, 
                ProjectId = 1, 
                Date = new DateTime(2022, 04, 10), 
                WorkedHours = 8 });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 3,
                EmployeeId = 3,
                ProjectId = 1,
                Date = new DateTime(2022, 04, 10),
                WorkedHours = 8
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 4,
                EmployeeId = 1,
                ProjectId = 1,
                Date = new DateTime(2022, 04, 08),
                WorkedHours = 12
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 5,
                EmployeeId = 2,
                ProjectId = 1,
                Date = new DateTime(2022, 04, 08),
                WorkedHours = 4
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 6,
                EmployeeId = 3,
                ProjectId = 1,
                Date = new DateTime(2022, 04, 07),
                WorkedHours = 8
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 7,
                EmployeeId = 4,
                ProjectId = 2,
                Date = new DateTime(2022, 04, 07),
                WorkedHours = 6
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 8,
                EmployeeId = 4,
                ProjectId = 2,
                Date = new DateTime(2022, 04, 07),
                WorkedHours = 8
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 9,
                EmployeeId = 5,
                ProjectId = 3,
                Date = new DateTime(2022, 04, 06),
                WorkedHours = 8
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 10,
                EmployeeId = 5,
                ProjectId = 3,
                Date = new DateTime(2022, 04, 06),
                WorkedHours = 8
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 11,
                EmployeeId = 5,
                ProjectId = 3,
                Date = new DateTime(2022, 04, 05),
                WorkedHours = 6
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 12,
                EmployeeId = 4,
                ProjectId = 2,
                Date = new DateTime(2022, 05, 04),
                WorkedHours = 6
            });

        }
    }
}
