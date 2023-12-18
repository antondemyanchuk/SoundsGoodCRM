namespace SoundsGoodCRM.Entities.Employees
{
    public class UserPermission : EntityWithId
    {
        public string Permission { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
