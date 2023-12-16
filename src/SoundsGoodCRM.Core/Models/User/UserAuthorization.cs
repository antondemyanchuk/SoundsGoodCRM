namespace SoundsGoodCRM.DAO.UserModels
{
    public class UserAuthorization : EntityWithId
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
        public UserAuthorization() { }
        public UserAuthorization(int id,string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
