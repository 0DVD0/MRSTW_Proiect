using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public string Name { get; set; }
        // Timespan is for months count for membership
        public TimeSpan TimeSpan { get; set; }
        public decimal Price { get; set; }
    }
}
