using eUseControl.BusinessLogic.Core;

namespace eUseControl.BusinessLogic.Interface
{
    public class BussinesLogic
    {
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
    }
}
