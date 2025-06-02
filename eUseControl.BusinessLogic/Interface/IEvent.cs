using eUseControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.EventTable;

namespace eUseControl.BusinessLogic.Interface
{
     public interface IEvent
     {
          List<EventTable> GetAllEvents();
          bool CreateEvent(EventTable webEvent);
     }
}
