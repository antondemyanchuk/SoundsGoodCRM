using Bogus;
using SoundsGoodCRM.Core.Entities.Customers;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeCustomer : Customer
    {
        internal FakeCustomer(int index, Faker faker, int[] randomNumbersArray)
        {
            Id = index + 1;
            FirstName = faker.Name.FirstName();
            LastName = faker.Name.LastName();
            ContactId = index + 1;
            PostId = randomNumbersArray[index];
            CustomerAuthorizationId = index + 1;
        }
    }
}
