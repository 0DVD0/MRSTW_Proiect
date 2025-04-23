using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.BaseEntities;

namespace WebsiteGym.Web.Models
{
    public class DiscountViewModel : BaseEntity
    {
        public string DiscountCode { get; set; }

        public decimal DiscountPercentage { get; set; }

        public List<DiscountDbTable> DiscountCodes { get; set; }
    }
}