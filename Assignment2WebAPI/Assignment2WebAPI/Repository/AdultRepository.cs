using System;
using Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment2WebAPI.Data;
using Assignment2WebAPI.Persistance;

namespace Assignment2WebAPI.Persistence
{
    public class AdultRepository : IAdult
    {
        private readonly CloudContext context;

        public AdultRepository(CloudContext context)
        {
            context = new CloudContext();
        }

        public async Task<Adult> AddAsync(Adult adult)
        {
            try
            {
                var newAddedAdult = await context.Adults.AddAsync(adult);
                await context.SaveChangesAsync();
                return newAddedAdult.Entity;
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public async Task<IList<Adult>> getAdults()
        {
            return await context.Adults.ToListAsync();
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult RemoveAdult = await context.Adults.FirstOrDefaultAsync(c => c.Id == adultId);
            if (RemoveAdult != null)
            {
                context.Adults.Remove(RemoveAdult);
                await context.SaveChangesAsync();
            }
        }


        public async Task<Adult> Update(Adult adult)
        {
            try
            {
                Adult adultUpdate = await context.Adults.FirstAsync(c => c.Id == adult.Id);
                context.Update(adultUpdate);
                await context.SaveChangesAsync();
                return adultUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($" Not found!");
            }
        }
    }
}