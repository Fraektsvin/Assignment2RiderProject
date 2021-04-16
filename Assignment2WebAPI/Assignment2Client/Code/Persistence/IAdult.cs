using System.Collections.Generic;
using Models;

namespace Blazor.code.persistence 
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