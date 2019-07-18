using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Queries
{
    public class StudentQueriesTest
    {
        private IList<Student> _student;
        public StudentQueriesTest()
        {
            for (var i = 0; i <= 10; i++)
            {
                _student.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@teste.com")
                ));
            }
        }

        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudent("12345678910");
            var studn = _student.AsQueryable().Where(exp).FirstOrDefault();
            Assert.Null(studn);
        }

        [Fact]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudent("11111111111");
            var studn = _student.AsQueryable().Where(exp).FirstOrDefault();
            Assert.NotNull(studn);
        }
    }
}