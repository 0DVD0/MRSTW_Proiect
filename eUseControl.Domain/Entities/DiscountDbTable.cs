using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    [Table("DiscountCodes")]
    public class DiscountDbTable : BaseEntity
    {
        public string DiscountCode { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
