using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.DBModel
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext() : base("name=eUseControl")
        {
        }
        public virtual DbSet<FeedbackDbTable> Feedbacks { get; set; }
    }
}
