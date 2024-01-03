using Bogus;
using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Services;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeCustomerAuthorization : CustomerAuthorization
    {
        public FakeCustomerAuthorization(int index,FakeContact fakeContact,Faker faker) 
        {
            Id = index + 1;
            Login = fakeContact.Email;
            PasswordHash = faker.Internet.Password().HashPassword();
        }
    }
}
