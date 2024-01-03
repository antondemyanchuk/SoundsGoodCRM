using Bogus;
using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Shared.Interfaces.EntitieInterfaces;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeContact : Contact
    {
        internal FakeContact(int index, Faker faker, IContactable fakeCustomer)
        {
            Id = index + 1;
            PhoneNumberPrimary = faker.Phone.PhoneNumber("+380 ## ### ## ##");
            PhoneNumberSecondary = faker.Phone.PhoneNumber("+380 ## ### ## ##");
            Email = faker.Internet.Email(fakeCustomer.FirstName, fakeCustomer.LastName);
        }
    }
}
