using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interface
{
    interface IMembershipApi
    {
        void CreateMembership(Membership membership);
    }
}
