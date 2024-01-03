using Bogus;
using SoundsGoodCRM.Core.Services;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeEmployeeAuthorization:EmployeeAuthorization
    {
        public FakeEmployeeAuthorization(int index,FakeContact contact, Faker faker) {
            Id = index + 1;
            Login = contact.Email;
            PasswordHash = faker.Internet.Password().HashPassword();
        }
    }
}
