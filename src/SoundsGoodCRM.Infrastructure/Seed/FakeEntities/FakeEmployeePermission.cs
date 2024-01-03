using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeDataHelpers;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeEmployeePermission : EmployeePermission
    {
        public FakeEmployeePermission(int index, FakeEmployeePermissionSpecification feps)
        {
            Id = index + 1;
            PermissionName = feps.employeePermissions[index];
        }
    }
}

