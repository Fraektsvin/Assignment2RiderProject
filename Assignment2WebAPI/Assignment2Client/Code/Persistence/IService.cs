using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2Client.Code.Persistence
{
    interface IService
    {
        Task addAdult(Adult adult);
        Task deleteAdult(int id);

        Task<List<Adult>> FetchAdultAsync();

        Task<Adult> GetAdult(int id);
    }
}
