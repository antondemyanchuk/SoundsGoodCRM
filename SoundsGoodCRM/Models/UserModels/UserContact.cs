namespace SoundsGoodCRM.Models.UserModels
{
    public class UserContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string PhoneNumberAlternative { get; set; }
        public string Email { get; set; }
        public string EmailAlternative { get; set; }
        public User User { get; set; }

    }
}
