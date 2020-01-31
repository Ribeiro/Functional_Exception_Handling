using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExceptionHandling
{
    public class Program
    {
        private static PaymentGateway _paymentGateway;
        private static Repository _repository;
        private static EmailSender _emailSender;

        public static void Main(string[] args)
        {
            _paymentGateway = new PaymentGateway();
            _repository = new Repository();
            _emailSender = new EmailSender();

            Result result = CreateCustomer("Geovanny Ribeiro", "85985401474");

        }

        public static Result CreateCustomer(string name, string billingInfo)
        {
            Result<BillingInfo> billingInfoResult = BillingInfo.Create(billingInfo);
            Result<CustomerName> customerNameResult = CustomerName.Create(name);

            return Result.Combine(billingInfoResult, customerNameResult)
                    .OnSuccess(() => _paymentGateway.ChargeCommission(billingInfoResult.Value))
                    .OnSuccess(() => new Customer(customerNameResult.Value))
                    .OnSuccess(customer => _repository.Save(customer)
                                           .OnFailure(() => _paymentGateway.RollbackLastTransaction()))
                    .OnSuccess(() => _emailSender.SendGreetings(customerNameResult.Value))
                    .OnBoth(result => Log(result));
        }

        private static void Log(Result result)
        {
            Console.WriteLine("Result is: " + result.ToString());
        }
    }
}
