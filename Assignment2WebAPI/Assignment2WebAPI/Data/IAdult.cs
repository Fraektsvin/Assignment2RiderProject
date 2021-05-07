using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2WebAPI.Data 
{
    public interface IAdult
    {
        Task RemoveAdult(int adultId);
        Task<Adult> Update(Adult adult);
        Task<IList<Adult>> getAdults();
        Task<Adult> AddAsync(Adult adult);
    }
}