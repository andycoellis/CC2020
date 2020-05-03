using System;
using System.ComponentModel.DataAnnotations;

namespace CC2020.Models
{
    public class Timesheet
    {
        //Timesheet Properties
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public TimeSpan Break { get; set; }


        //Timesheet Foreign Keys
        [Required]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public long CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
