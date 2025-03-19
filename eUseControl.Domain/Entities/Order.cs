using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities
    {
        public class Order
        {
            public int Id { get; set; }
            public int MembershipId { get; set; }
            public DateTime OrderDate { get; set; }
        }
    }


