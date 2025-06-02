using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using eUseControl.Domain.Entities.BaseEntities;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.EventTable
{
     [Table("Events")]
     public class EventTable : BaseEntity
     {
          [Required(ErrorMessage = "Username is required!")]
          public string UserName { get; set; }
          [Required(ErrorMessage = "WebAction required!")]
          public string Action { get; set; }
          [Required(ErrorMessage = "Event Time required!")]
          public DateTime EventTime { get; set; }
     }
}
