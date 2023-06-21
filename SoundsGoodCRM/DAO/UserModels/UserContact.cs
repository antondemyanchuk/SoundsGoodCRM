namespace SoundsGoodCRM.DAO.UserModels
{
    public class UserContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public User User { get; set; }

    }
}
