using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.Order
{
    public class NewOrderDto
    {
        public int Id { get; set; }

        public int membershipName { get; set; }

        public DateTime orderDate { get; set; }

        public int totalPrice { get; set; }

        public int userName { get; set; }
    }
}
