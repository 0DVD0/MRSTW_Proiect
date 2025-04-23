using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace WebsiteGym.Web.Models
{
    public class MembershipViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Membership Name is required")]
        [Display(Name = "Membership Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Membership Name is not valid")]
        public string MembershipName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Details are required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<MDbTable> Memberships { get; set; }
    }
}