using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData
{
    internal record FakeOrderSpecification
    {
        internal string[] orderStatuses = ["Received", "On diagnostic", "Pending", "Waiting for repair parts", "Canceled", "Done", "Ready for sending", "Send"];
        internal string[] orderTasks = ["Soldering",
            "Repadding",
            "Flat spring removing/installing",
            "Needle spring removing/installing",
            "Oiling",
            "Chemical cleaning",
            "Foot join cork removing/installing",
            "Cracks fixing",
            "Carbon rings installing",
            "Dent removing"];
        internal FakeOrderSpecification() { }
        internal FakeOrderSpecification(string[] orderStatuses, string[] orderTasks)
        {
            this.orderStatuses = orderStatuses;
            this.orderTasks = orderTasks;
        }
    }
}
