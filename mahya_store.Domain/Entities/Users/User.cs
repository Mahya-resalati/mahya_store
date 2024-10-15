using mahya_store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Domain.Entities.Users
{
    public class User:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<UserInRole> userInRoles { get; set; }

    }
}
