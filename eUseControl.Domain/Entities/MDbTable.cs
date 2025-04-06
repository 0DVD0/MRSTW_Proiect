using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class MDbTable : BaseEntity
    {
        [Required]
        [Display(Name = "Membership Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Membership Name is not valid")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "MembershipTimeSpan")]
        // Timespan is for months count for membership
        public TimeSpan TimeSpan { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "DiscountPrice")]
        public decimal? DiscountPrice { get; set; }
    }
}
