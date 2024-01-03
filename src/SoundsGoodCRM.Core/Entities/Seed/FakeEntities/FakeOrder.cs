using Bogus;
using Bogus.DataSets;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeOrder : Order
    {
        public FakeOrder(int index, int counter, int employeeCounter, FakeOrderSpecification fos, Faker faker)
        {
            Id = index + 1;
            CustomerId = faker.Random.Number(1, counter);
            InstrumentId = faker.Random.Number(1, counter);
            CreatedAt = faker.Date.Recent(365);
            OrderStatusId = faker.Random.Number(1, fos.orderStatuses.Length);
            Description = faker.Commerce.ProductDescription();
            //TODO: Create a function to count Amount
            TotalAmount = faker.Commerce.Price(1, 15000, 2, "₴");
            EmployeeId = faker.Random.Number(1, employeeCounter);
            AddTaskId(fos,faker);
            ComplitedAt = faker.Date.Soon(14, CreatedAt);
        }
        private void AddTaskId(FakeOrderSpecification fos, Faker faker)
        {
            for (int j = 0; j < 5; j++)
            {
                OrderTaskId.Add(faker.Random.Number(1, fos.orderTasks.Length));
            }
        }
    }
}
