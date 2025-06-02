using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.BusinessLogic.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
     public class FeedbackAPI : IFeedback
     {
          public List<FeedbackDbTable> GetAllFeedbacks()
          {
               var _context = new FeedbackContext();
               var feedbacks = _context.Feedbacks.ToList();
               return feedbacks;
          }

          public bool CreateFeedback(FeedbackDbTable feedback)
          {
               if (feedback == null)
               {
                    return false;
               } 
               else 
               { 
                    using (var context = new FeedbackContext())
                    {
                         context.Feedbacks.Add(feedback);
                         context.SaveChanges();
                    }
                    return true;
               }
          }

          public bool RemoveFeedback(FeedbackDbTable feedback)
          {
               if (feedback == null)
               {
                    return false;
               } else { 
                    
               using (var context = new FeedbackContext())
               {
                    var feedbackToRemove = context.Feedbacks.FirstOrDefault(f => f.Id == feedback.Id);
                    if (feedbackToRemove != null)
                    {
                         context.Feedbacks.Remove(feedbackToRemove);
                         context.SaveChanges();
                    }
               }
                    return true;
               }
          }

          public bool EditFeedback(FeedbackDbTable feedback)
          {
               if (feedback == null)
               {
                    return false;
               }
               else
               {
                    using (var context = new FeedbackContext())
                    {
                         var feedbackToEdit = context.Feedbacks.FirstOrDefault(f => f.Id == feedback.Id);
                         if (feedbackToEdit != null)
                         {
                              //feedbackToEdit.UserId = feedback.UserId;
                              //feedbackToEdit.Rating = feedback.Rating;
                              //feedbackToEdit.Comment = feedback.Comment;
                              context.SaveChanges();
                         }
                    }
                    return true;
               }
          }

          public int GetTotalNumberOfFeedbacks()
          {
               using (var context = new FeedbackContext())
               {
                    return context.Feedbacks.Count();
               }
          }
     }
}
