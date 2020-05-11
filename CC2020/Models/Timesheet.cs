using System;
using System.ComponentModel.DataAnnotations;

namespace CC2020.Models
{
    public class Timesheet
    {
        //Timesheet Properties
        [Key]
        public int ID { get; set; }

        private DateTime _scheduleDate;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date
        {
            get => _scheduleDate.Date;

            set => _scheduleDate = value.Date;
        }

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
