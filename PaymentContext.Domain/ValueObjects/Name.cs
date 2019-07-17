using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
              .Requires()
              .HasMinLen(FirstName, 3, "FirstName", "First Name must contains a minimum of 3 characters.")
              .HasMaxLen(FirstName, 40, "LastName", "First Name must contains a maximum of 40 characters.")
              .HasMinLen(LastName, 3, "FirstName", "Last Name must contains a minimum of 3 characters.")
              .HasMaxLen(LastName, 40, "LastName", "Last Name must contains a maximum of 40 characters"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
    }
}