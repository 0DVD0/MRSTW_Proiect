using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.BaseEntities;

namespace WebsiteGym.Web.Models
{
    public class DiscountViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Discount Code is required.")]
        [Display(Name = "Discount Code")]
        public string DiscountCode { get; set; }

        [Required(ErrorMessage = "Discount Percentage is required.")]
        [Display(Name = "Discount Percentage")]
        public decimal? DiscountPercentage { get; set; }

        public List<DiscountDbTable> DiscountCodes { get; set; }
    }
}