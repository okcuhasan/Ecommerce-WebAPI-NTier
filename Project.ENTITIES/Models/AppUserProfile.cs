using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Relational Properties

        public virtual AppUser AppUser { get; set; } // Bir profilin bir kullanıcısı vardır - AppUser ile bire bir ilişki
        // virtual ile ezmek isteyebilirim
    }
}
