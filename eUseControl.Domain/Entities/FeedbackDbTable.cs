using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.BaseEntities;

namespace eUseControl.Domain.Entities
{
    public class FeedbackDbTable : BaseEntity
    {
       public string UserName { get; set; }
       public string Email {  get; set; }
       public string FeedbackMessage { get; set; }
    }
}
