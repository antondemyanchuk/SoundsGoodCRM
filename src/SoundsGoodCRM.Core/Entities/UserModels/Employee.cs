namespace SoundsGoodCRM.Entities.Employees
{
    public class Employee : EntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserContactsId { get; set; }
        public int UserPermissionsId { get; set; }
        public int UserAuthorizationId { get; set; }
        public EmployeeContact UserContact { get; set; }
        public UserPermission UserPermission { get; set; }
        public EmployeeAuthorization UserAuthorization { get; set; }
        public Employee() { }
        public Employee(int id, string firstName, string lastName, int userContactsId, int userPermissionsId, int userAuthorizationId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserContactsId = userContactsId;
            UserPermissionsId = userPermissionsId;
            UserAuthorizationId = userAuthorizationId;
        }
    }
}
