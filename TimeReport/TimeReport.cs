using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace TimeReport
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hours worked is required")]
        [Range(0, 12, ErrorMessage = "Hours worked needs to be between 0-12")]
        public int WorkedHours { get; set; }
        public int Week
        {
            get => CultureInfo.InvariantCulture.Calendar.
            GetWeekOfYear(Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }
    }
}
