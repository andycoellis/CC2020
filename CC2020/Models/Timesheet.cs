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
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public TimeSpan Break { get; set; }


        //Timesheet Foreign Keys
        [Required]
        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public long CompanyABN { get; set; }
        public virtual Company Company { get; set; }
    }
}
