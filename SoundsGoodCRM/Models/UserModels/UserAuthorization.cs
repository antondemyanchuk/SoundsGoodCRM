namespace SoundsGoodCRM.Models.UserModels
{
    public class UserAuthorization : EntityWithId
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
