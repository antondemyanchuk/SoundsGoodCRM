using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeOrderStatus : OrderStatus
    {
        internal FakeOrderStatus(int index, FakeOrderSpecification fos) 
        { 
            Id = index; 
            StatusName = fos.orderStatuses[index]; 
        }
    }
}
