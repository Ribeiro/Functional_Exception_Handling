using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExceptionHandling
{
    public class CustomerName
    {
        internal static Result<CustomerName> Create(string name)
        {
            throw new NotImplementedException();
        }
    }
}
