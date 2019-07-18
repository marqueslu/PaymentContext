using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.handlers;
using PaymentContext.Tests.Mocks;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTest
    {
        [Fact]
        public void ShouldReturnErrorWhenDocumentExists(){
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName  = "Bruce";
            command.LastName  = "Wayne";
            command.Document  = "99999999999";
            command.Email  = "teste@teste.com";
            command.BarCode  = "123456789";
            command.BoletoNumber  = "123456879";
            command.PaymentNumber  = "1234587";
            command.PaidDate  = DateTime.Now;
            command.ExpireDate  = DateTime.Now.AddMonths(1);
            command.Total  = 60;
            command.TotalPaid  = 60;
            command.Payer  = "Wayne Corp";
            command.PayerDocument  = "12332112310";
            command.PayerDocumentType  = EDocumentType.CPF;
            command.PayerEmail  = "batman@bruce.com";
            command.Street  = "lala";
            command.Number  = "123";
            command.Neighborhood  = "lala";
            command.City  = "few";
            command.State  = "wer";
            command.Country  = "werw";
            command.ZipCode  = "12312310";

            handler.Handle(command);
            Assert.False(handler.Valid);
        }
    }
}