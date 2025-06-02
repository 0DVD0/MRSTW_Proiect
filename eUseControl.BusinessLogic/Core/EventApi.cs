using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.EventTable;
using eUseControl.BusinessLogic.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
     public class EventApi : IEvent
     {
          public List<EventTable> GetAllEvents()
          {
               using (var context = new EventContext())
               {
                    return context.Events.OrderByDescending(e => e.EventTime).ToList();
               }
          }

          public bool CreateEvent(EventTable webEvent)
          {
               if (webEvent == null)
               {
                    return false;
               }
               else
               {
                    using (var context = new EventContext())
                    {
                         context.Events.Add(webEvent);
                         context.SaveChanges();
                    }
                    return true;
               }
          }


     }
}
