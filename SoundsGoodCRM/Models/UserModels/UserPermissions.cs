namespace SoundsGoodCRM.Models.UserModels
{
    public class UserPermission : EntityWithId
    {
        public string Permission { get; set; }
        public List <User> Users { get; set; }
    }
}
