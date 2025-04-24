using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Discount;

namespace eUseControl.BusinessLogic.Interface
{
    public interface IDiscountCode
    {
        void CreateDiscountCode(NewDiscountDto discount);
        void RemoveDiscountCode(NewDiscountDto discount);
        void EditDiscountCode(NewDiscountDto discount);
        DiscountDbTable GetDiscountCodeById(NewDiscountDto discount);
        List<DiscountDbTable> GetAllDiscountCodes();
    }

}
