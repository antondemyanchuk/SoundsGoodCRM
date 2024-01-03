namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeDataHelpers
{
    internal sealed record FakeEmployeePermissionSpecification
    {
        internal readonly string[] employeePermissions = ["Admin", "Technician", "Supervisor"];

        internal FakeEmployeePermissionSpecification() { }
        internal FakeEmployeePermissionSpecification(string[] employeePermissions) { this.employeePermissions = employeePermissions; }
    }
}
