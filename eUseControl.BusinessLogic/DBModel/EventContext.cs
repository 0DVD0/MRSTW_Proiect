using System;
using System.Collections.Generic;
using eUseControl.Domain.Entities.EventTable;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
     public class EventContext : DbContext
     {

          public EventContext() : base("name=eUseControl")
          {
          }
          public virtual DbSet<EventTable> Events { get; set; }
     }
}
