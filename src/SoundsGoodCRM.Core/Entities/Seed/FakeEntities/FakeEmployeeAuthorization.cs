using Bogus;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeEmployeeAuthorization:EmployeeAuthorization
    {
        public FakeEmployeeAuthorization(int index,FakeContact contact, Faker faker) {
            Id = index + 1;
            Login = contact.Email;
            //TODO: Add hashing to the password
            PasswordHash = faker.Internet.Password();
        }
    }
}
