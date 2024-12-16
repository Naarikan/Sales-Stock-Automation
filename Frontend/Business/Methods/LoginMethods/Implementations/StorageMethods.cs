using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using Business.Methods.LoginMethods.Interfaces;



namespace Business.Methods.LoginMethods.Implementations
{
    public class StorageMethods:IStorageMethods
    {
        ILocalStorageService _localStorageService;
        HttpClient _httpClient;

        public StorageMethods(ILocalStorageService localStorageService,HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

    

        public async Task SetLocalStorage(string storageName, string token)
        {
            await _localStorageService.SetItemAsync(storageName, token);
        }

        public int GetUserId(List<Claim> claims)
        {
            var id= claims.FirstOrDefault(c=>c.Type=="Id");
            if (id != null && int.TryParse(id.Value, out int userId))
            {
                return userId;
            }
            return -1;
        }
    }
}
