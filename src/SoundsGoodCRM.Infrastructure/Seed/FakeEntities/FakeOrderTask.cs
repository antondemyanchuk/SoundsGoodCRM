using Bogus;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeOrderTask : OrderTask
    {
        public FakeOrderTask(int index, FakeOrderSpecification fos, Faker faker) 
        {
            Id = index;
            TaskName = fos.orderTasks[index];
            Value = faker.Random.Decimal(250.00m, 10000.00m);
        }
    }
}
