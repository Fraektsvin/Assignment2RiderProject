using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2WebAPI.Data 
{
    public interface IAdult
    {
        void SaveChanges(Person addAdult);
        IList<T> ReadData<T>(string s);
        void RemoveAdult(int adultId);
        Adult get(int id);
        void Update(Adult adult);
        IList<Adult> getAdults();
        void addData(Adult adult);
    }
}