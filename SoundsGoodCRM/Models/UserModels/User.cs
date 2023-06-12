using SoundsGoodCRM.Models.UserModels;

namespace SoundsGoodCRM.Models
{
    public class User : EntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserContactsId { get; set; }
        public int UserPermissionsId { get; set; }
        public int UserAuthorizationId { get; set; }
        public UserContact UserContact { get; set; }
        public UserPermission UserPermission { get; set; }
        public UserAuthorization UserAuthorization { get; set; }

    }
}
