using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities.Order
{
    public class NewOrderDto : BaseEntity
    {
        public string membershipName { get; set; }

        public string userName { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime endDate { get; set; }

        public decimal subtotalPrice { get; set; }

        public decimal totalPrice { get; set; }

        public decimal discountAmount { get; set; }

        public int membershipDuration  { get; set; }
        
    }
}
