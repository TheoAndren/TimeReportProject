using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeReport
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project name required")]
        public string ProjectName { get; set; }
        public List<TimeReport> TimeReports { get; set; }

    }
}
