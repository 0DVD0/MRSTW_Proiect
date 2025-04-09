using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteGym.Web.Models
{
    public class MembershipViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Membership Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Membership Name is not valid")]
        public string MembershipName { get; set; }

        [Required]
        [Display(Name = "Membership Time Span")]
        public int TimeSpanMonths { get; set; } 

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Discount Price")]
        public decimal? DiscountPrice { get; set; }

    }
}