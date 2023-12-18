namespace SoundsGoodCRM.Entities.Employees
{
    public class EmployeeContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Employee Employee { get; set; }

        public EmployeeContact() { }
        public EmployeeContact(int id, string phoneNumber, string email)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
