using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi, IOrderApi
    {
        public void CreateMembership(Membership membership)
        {
            // TODO
            // some logic to create membership
            // validate membership
            // if is not valid, throw new error
            // add some other logic
        }
    }
}
