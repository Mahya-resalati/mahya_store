using mahya_store.Domain.Entities.Commons;

namespace mahya_store.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> userInRoles { get; set; }
    }
}
