using Bogus;
using SoundsGoodCRM.Entities.Employees;
using SoundsGoodCRM.Shared.Interfaces.EntitieInterfaces;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeEmployee:Employee,IContactable
    {
        readonly string[] _employeePermissions;
        public FakeEmployee(int idIndex,int quantity, string[] employeePermissions, Faker faker) 
        {
            _employeePermissions = employeePermissions;
            Id = idIndex + 1;
            FirstName = faker.Name.FirstName();
            LastName = faker.Name.LastName();
            EmployeeAuthorizationId = idIndex + 1;
            EmployeePermissionId = faker.Random.Number(1, _employeePermissions.Length);
            ContactId = quantity + 1;
        }
    }
}
