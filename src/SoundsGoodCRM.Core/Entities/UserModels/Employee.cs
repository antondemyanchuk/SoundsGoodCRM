using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Core.Entities.Orders;

namespace SoundsGoodCRM.Entities.Employees
{
    public class Employee : EntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeAuthorizationId { get; set; }
        public int EmployeePermissionsId { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public EmployeeAuthorization EmployeeAuthorization { get; set; }
        public EmployeePermission EmployeePermission { get; set; }
        public List<Order> Orders { get; set; }
    }
}
