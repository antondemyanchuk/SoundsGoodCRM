namespace SoundsGoodCRM.DTO
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        
        public string ReturnUrl { get; set; }
        public UserAuthDTO() { }
        public UserAuthDTO(int id, int userId, int permissionId, string login, string password, string permission)
        {
            Id = id;
            UserId = userId;
            PermissionId = permissionId;
            Login = login;
            Password = password;
            Permission = permission;
        }
    }
}
