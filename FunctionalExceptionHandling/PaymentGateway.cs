using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExceptionHandling
{
    public class PaymentGateway
    {
        internal Result ChargeCommission(BillingInfo value)
        {
            throw new NotImplementedException();
        }

        internal void RollbackLastTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
