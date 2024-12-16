using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Business.Methods.LoginMethods.Interfaces
{
    public interface IStorageMethods
    {
        Task SetLocalStorage(string storageName, string token);
        int GetUserId(List<Claim> claims);


    }
}
