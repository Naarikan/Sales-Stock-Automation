using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Methods.LoginMethods.Interfaces
{
    public interface IAuthMethods
    {
        Task CheckAuthBeforeRequests();
        Task<string> GetClaim(string claimType);
    }
}
