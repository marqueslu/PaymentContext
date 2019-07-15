using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class DocumentTest
    {
        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.True(doc.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("85980680000100", EDocumentType.CNPJ);
            Assert.True(doc.Valid);
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.True(doc.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var doc = new Document("89720281006", EDocumentType.CPF);
            Assert.True(doc.Valid);
        }
    }
}