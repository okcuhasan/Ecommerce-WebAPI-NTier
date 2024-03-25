using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileManager
    {
        IAppUserProfileRepository _iapRep;
        public AppUserProfileManager(IAppUserProfileRepository iapRep) : base(iapRep)
        {
            _iapRep = iapRep;
        }


    }
}
