namespace SoundsGoodCRM.Entities.Employees
{
    public class EmployeePermission : EntityWithId
    {
        public string PermissionName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
