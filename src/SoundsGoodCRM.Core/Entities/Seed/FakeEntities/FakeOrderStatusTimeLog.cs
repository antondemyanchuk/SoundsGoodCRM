using Bogus;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeOrderStatusTimeLog : OrderStatusTimeLog
    {
        public FakeOrderStatusTimeLog(Order order, FakeOrderSpecification fos, Faker faker)
        {
            DateTime = faker.Date.Between(order.CreatedAt,order.ComplitedAt);
            OrderStatusId = faker.Random.Number(1,fos.orderStatuses.Length);
            OrderId = order.Id ;
        }
    }
}

