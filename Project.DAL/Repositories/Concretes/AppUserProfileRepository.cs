using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserProfileRepository : BaseRepository<AppUserProfile>, IAppUserProfileRepository
    {
        // AppUserProfileRepository sınıfı new lendiğinde ilk olarak AppUserProfileRepository sınıfının constructor ı çağırılacak 
        // ve AppUserProfileRepository üzerinden BaseRepository sınıfındaki metotlar çağırılacak. Burada BaseRepository sınıfındaki metotlar çağırılırken
        // BaseRepository nin constructor ında MyContext sınıfı new leniyor new lenen sınıf instance ı AppUserProfileRepository sınıfının constructor ındaki
        // MyContext nesnesi ile uyumlu olmalıdır ki AppUserProfileRepository sınıfı doğru bir biçimde new lenebilsin
        // Bundan dolayı AppUserProfileRepository sınıfının constructor ında alınan MyContext sınıfının nesnesi olan db nesnesi base e yani BaseRepository sınıfının
        // constructor ına gönderiliyor
        public AppUserProfileRepository(MyContext db) : base(db) 
        {

        }
    }
}
