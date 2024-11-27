using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmpName { get; set; }

        [Required] 
        public DateTime DOB { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal EmpSalary { get; set; }

    }
}
