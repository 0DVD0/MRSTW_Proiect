using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Entities.User;

namespace eUseControl.Domain.Entities
{
    public class ODbTable
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Membership ID")]
        public int MembershipId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public int UserId { get; set; }
    }
}


