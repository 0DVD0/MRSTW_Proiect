using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.Domain.Entities;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interface
{
     public interface IFeedback
     {
          List<FeedbackDbTable> GetAllFeedbacks();
          bool CreateFeedback(FeedbackDbTable feedback);
          bool RemoveFeedback(FeedbackDbTable feedback);
          bool EditFeedback(FeedbackDbTable feedback);
          int GetTotalNumberOfFeedbacks();

     }
}
