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
        public int membershipName { get; set; }

        public int userName { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime endDate { get; set; }

        public int subtotalPrice { get; set; }

        public int totalPrice { get; set; }

        public int discountAmount { get; set; }
    }
}
