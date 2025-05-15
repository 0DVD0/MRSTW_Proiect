using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    [Table("Memberships")]
    public class MDbTable : BaseEntity
    {
        [Required]
        [Display(Name = "Membership Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Membership Name is not valid")]
        public string MembershipName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Details")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Details are not valid")]
        public string Details { get; set; }
    }
}
