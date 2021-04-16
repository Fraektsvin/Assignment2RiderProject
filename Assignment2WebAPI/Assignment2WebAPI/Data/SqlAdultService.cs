using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Assignment2WebAPI.Persistence;
using Assignment2WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Assignment2WebAPI.Data
{
    public class SqliteTodoService : IAdult
    {
        private TodoContext ctx;

        public SqliteTodoService(TodoContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IList<Adult>> getAdults()
        {
            return await ctx.Adults.ToListAsync();
        }

        public async Task<Adult> addData(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public void SaveChanges(Person addAdult)
        {
            throw new NotImplementedException();
        }

        public IList<T> ReadData<T>(string s)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAdult(int todoId)
        {
            Adult toDelete = await ctx.Adults.FirstOrDefaultAsync(t => t.Id == todoId);
            if (toDelete != null)
            {
                ctx.Adults.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

        public Adult get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Adult> Update(Adult adult)
        {
            try
            {
                Adult toUpdate = await ctx.Adults.FirstAsync(t => t.Id == adult.Id);
                toUpdate.IsCompleted = adult.IsCompleted;
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find Adult with id{adult.Id}");
            }
        }
    }
}