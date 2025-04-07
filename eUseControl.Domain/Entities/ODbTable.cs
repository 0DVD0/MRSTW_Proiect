using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.BaseEntities;   

namespace eUseControl.Domain.Entities
{
    public class ODbTable : BaseEntity
    {

        [Required]
        [Display(Name = "User name")]
        public int UserName { get; set; }

        [Required]
        [Display(Name = "Membership name")]
        public int MembershipName { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }

      
    }
}


