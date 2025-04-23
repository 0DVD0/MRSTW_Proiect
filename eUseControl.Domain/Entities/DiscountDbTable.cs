using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class DiscountDbTable : BaseEntity
    {
        public string DiscountCode { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
