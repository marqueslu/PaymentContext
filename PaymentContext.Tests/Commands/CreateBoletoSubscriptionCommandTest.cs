using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Tests.Commands
{
    public class CreateBoletoSubscriptionCommandTest
    {
        [Fact]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.Validate();
            Assert.False(command.Valid);
        }
    }
}