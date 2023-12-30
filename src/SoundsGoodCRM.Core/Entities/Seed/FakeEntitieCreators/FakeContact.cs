using Bogus;
using SoundsGoodCRM.Core.Entities.DataModels;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntitieCreators
{
    internal sealed class FakeContact:Contact
    {
        internal FakeContact(int index, Faker faker, FakeCustomer fakeCustomer) 
        {
            Id = index + 1;
            PhoneNumberPrimary = faker.Phone.PhoneNumber("+380 ## ### ## ##");
            PhoneNumberSecondary = faker.Phone.PhoneNumber("+380 ## ### ## ##");
            Email = faker.Internet.Email(fakeCustomer.FirstName, fakeCustomer.LastName);
        }
    }
}
