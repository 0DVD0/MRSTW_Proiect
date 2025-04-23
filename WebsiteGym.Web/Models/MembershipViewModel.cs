using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities;

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
        [Display(Name = "Price")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public List<MDbTable> Memberships { get; set; }
    }
}