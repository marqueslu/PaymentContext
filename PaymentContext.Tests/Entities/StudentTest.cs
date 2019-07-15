using System;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("89720281006", EDocumentType.CPF);
            _email = new Email("bruce@wayne.com");
            _subscription = new Subscription(null);
            _student = new Student(_name, _document, _email);
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "12345678");

        }
        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);            

            Assert.True(_student.Valid);
        }
    }
}