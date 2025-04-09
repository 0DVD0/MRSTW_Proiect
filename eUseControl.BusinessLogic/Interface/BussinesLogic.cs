using eUseControl.BusinessLogic.Core;

namespace eUseControl.BusinessLogic.Interface
{
    public class BussinesLogic
    {
        public IOrderApi GetOrderApi()
        {
            return new OrderApi();
        }
    }
}
