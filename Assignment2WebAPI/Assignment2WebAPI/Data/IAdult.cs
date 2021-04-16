using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2WebAPI.Data 
{
    public interface IAdult
    {
        void SaveChanges(Person addAdult);
        IList<T> ReadData<T>(string s);
        Task RemoveAdult(int adultId);
        Adult get(int id);
        Task<Adult> Update(Adult adult);
        Task<IList<Adult>> getAdults();

        Task<Adult> addData(Adult adult);
    }
}