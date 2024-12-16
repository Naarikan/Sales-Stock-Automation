using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
    public interface ILocalityService
    {
        Task<List<LocalityModel>> GetLocalitiesAsync();
		Task<List<LocalityModel>> GetSubLocalitiesAsync(int id);
		Task<LocalityModel> GetSubLocality(int parentid);
		Task<LocalityModel> GetLocalityByIdAsync(int id);
        Task AddLocalityAsync(LocalityModel Locality);
        Task UpdateLocalityAsync(LocalityModel Locality);
        Task DeleteLocalityAsync(int id);
    }
}
