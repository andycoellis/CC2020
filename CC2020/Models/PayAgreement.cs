using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC2020.Models
{
    public class PayAgreement
    {
        //Agreement Properties
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d+$")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PayRate { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d+$")]
        public double SaturdayRate { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d+$")]
        public double SundayRate { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d+$")]
        public double PublicHolidayRate { get; set; }


        //Agreement Foreign Keys
        [Required]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public long CompanyID { get; set; }
        public virtual Company Company { get; }
    }
}
