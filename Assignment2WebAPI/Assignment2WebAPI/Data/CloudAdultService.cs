using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Assignment2WebAPI.Persistence;
using Assignment2WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.IO;

namespace Assignment2WebAPI.Data
{
    public class CloudTodoService 
    {

        private string uri = "https://localhost:5003/";
        // private string uri = "http://jsonplaceholder.typicode.com";
        private readonly HttpClient client;
        private TodoContext _todoContext;

        public CloudTodoService()
        {
            _todoContext = new TodoContext();
            client = new HttpClient();
        }

      
        public Task<Adult> addData(Adult adult)
        {
            throw new NotImplementedException();
        }

       
        public Adult get(int id)
        {
            /*Task<string> stringAsync = client.GetStringAsync(uri + $"/Adult?id={id}");
            string message = await stringAsync;
            var result = JsonSerializer.Deserialize<Adult>(message);
            return result;*/

            return new Adult("titel",false,id);
        }

        public async Task<IList<Adult>> getAdults()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public IList<T> ReadData<T>(string s)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAdult(int adultId)
        {
            await client.DeleteAsync($"{uri}/Adults/{adultId}");
        }

        public async Task Update(Adult adult)
        {
            string todoAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/Adults/{adult.Id}", content);
           
        }
    }
    }