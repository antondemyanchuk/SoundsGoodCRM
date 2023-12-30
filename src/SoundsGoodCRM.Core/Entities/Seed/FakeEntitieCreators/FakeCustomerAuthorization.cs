using Bogus;
using SoundsGoodCRM.Core.Entities.Customers;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntitieCreators
{
    internal sealed class FakeCustomerAuthorization : CustomerAuthorization
    {
        public FakeCustomerAuthorization(int index,FakeContact fakeContact,Faker faker) 
        {
            Id = index + 1;
            Login = fakeContact.Email;
            //TODO: Add hashing to the password
            PasswordHash = faker.Internet.Password();
        }
    }
}
