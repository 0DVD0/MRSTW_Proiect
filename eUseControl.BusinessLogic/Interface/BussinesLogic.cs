using eUseControl.BusinessLogic.Core;

namespace eUseControl.BusinessLogic.Interface
{
     public class BussinesLogic
     {

          public IUserServices GetUserApi()
          {
               return new UserServices();
          }
          public IOrderApi GetOrderApi()
          {
               return new OrderApi();
          }

          public IMembershipApi GetMembershipApi()
          {
               return new AdminApi();
          }

          public IDiscountCode GetDiscountApi()
          {
               return new AdminApi();
          }

          public IFeedback GetFeedbackApi()
          {
               return new FeedbackAPI();
          }

          public ICoachApi GetCoachApi()
          {
               return new AdminApi();
          }

          public IEvent GetEventApi()
          {
               return new EventApi();
          }
     }
}
