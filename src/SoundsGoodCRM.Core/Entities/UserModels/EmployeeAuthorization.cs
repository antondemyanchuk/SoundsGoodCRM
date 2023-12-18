namespace SoundsGoodCRM.Entities.Employees
{
    public class EmployeeAuthorization : EntityWithId
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }
        public EmployeeAuthorization() { }
        public EmployeeAuthorization(int id,string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
