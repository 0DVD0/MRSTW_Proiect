using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGym.Web.Models
{
    public class OrderViewModel // ACESTEA Se vor SALVA in DB!!!!!! NOI DOAR de acestea avem nevoie
    {
        public int OrderId { get; set; } 
        public int MembershipName { get; set; }  
        public int UserName { get; set; }
        public int MembershipDuration { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal Subtotal { get; set; }  
        public int TotalPrice { get; set; }

        //CA IN CHeckoutMembership.cshtml sa mearga
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpDate { get; set; }
        public int Duration { get; set; }

    }
}