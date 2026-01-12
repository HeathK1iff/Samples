
using Samples.NullObject;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Samples.Tests.Patterns
{
    public class NullObjectTests
    {
        [Fact]
        public void CreatePayment_CreateNullPayment_True()
        {
            IPaymentTransactionFactory factory = CreateFactory(new DateTime(2024, 01, 09));

            Payment transctionInThePast = factory.CreatePayment(new DateTime(2024, 01, 08));

            Assert.Equal(Payment.Null, transctionInThePast);
        }

        [Fact]
        public void CreatePayment_CreateAdvancePayment_True()
        {
            IPaymentTransactionFactory factory = CreateFactory(new DateTime(2024, 01, 09));

            Payment transaction = factory.CreatePayment(new DateTime(2024, 01, 10));

            Assert.True(transaction is AdvancePayment);
        }

        [Fact]
        public void CreatePayment_CreateNetPayment_True()
        {
            IPaymentTransactionFactory factory = CreateFactory(new DateTime(2024, 01, 09));

            Payment transaction = factory.CreatePayment(new DateTime(2024, 01, 31));

            Assert.True(transaction is NetPayment);
        }

        private IPaymentTransactionFactory CreateFactory(DateTime today)
        {
            return new DateBasedPaymentTransactionFactoryDateAccess(today);
        }

        private class DateBasedPaymentTransactionFactoryDateAccess : DateBasedPaymentTransactionFactory
        {
            private DateTime _today;
            public DateBasedPaymentTransactionFactoryDateAccess(DateTime today)
            {
                _today = today;
            }

            protected override DateTime GetToday()
            {
                return _today;
            }
        }

    }
}