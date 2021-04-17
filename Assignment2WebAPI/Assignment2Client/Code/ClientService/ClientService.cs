using Assignment2Client.Code.Persistence;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment2Client.Code.ClientService
{
    public class ClientService : IService
    {

        private string uri = "https://localhost:5002";

        public async Task<List<Adult>> FetchAdultAsync()  {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("https://localhost:5002/Adults");

            if (!message.IsSuccessStatusCode)
                throw new Exception(@"Error: {message.StatusCode}, {message.ReasonPhrase}");

            string result = await message.Content.ReadAsStringAsync();


            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adults;
        }
        public async Task addAdult(Adult adult)
        {
            HttpClient client = new HttpClient();
            

            String AdultAsJson = JsonSerializer.Serialize(adult);
        
            StringContent content = new StringContent(
                AdultAsJson,
                Encoding.UTF8,
                "application/json"
                );

            HttpResponseMessage response = await client.PostAsync($"{uri}{"/Adults"}", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {message.StatusCode}, {message.ReasonPhrase}");



        }

        public async Task deleteAdult(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync($"{uri}/Adults/{id}");
            if(!message.IsSuccessStatusCode)
                throw new Exception(@"Error: {message.StatusCode}, {message.ReasonPhrase}");

        }

        public async Task<Adult> GetAdult(int id)
        {
            HttpClient client = new HttpClient();
            Task<string> stringAsync = client.GetStringAsync(uri + $"/adults/{id}");
            string message = await stringAsync;
            var result = JsonSerializer.Deserialize<Adult>(message);
            return result;
        }


    }
}
