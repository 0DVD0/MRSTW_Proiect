using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.DBModel
{
     public class CoachContext: DbContext
     {
          public CoachContext() : base("name=eUseControl")
          {
          }
          public virtual DbSet<Coach> Coaches { get; set; }
     }
}
