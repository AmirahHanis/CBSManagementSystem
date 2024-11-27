using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSManagementSystem.Models
{
    public class Donation
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DonorName { get; set; }


        [Required] 
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [Required]
        [MaxLength(500)]
        public string ItemDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

    }

}
