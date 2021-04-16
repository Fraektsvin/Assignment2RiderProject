using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;


namespace Assignment2WebAPI.Data
{
    public class WebApi : IAdult
    {

        public IList<Family> Families;
        public IList<Adult> Adults;

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public WebApi() {
            if (!File.Exists(adultsFile)) {
                Seed();
                string adultJson = JsonSerializer.Serialize(Adults);
                File.WriteAllText(adultsFile, adultJson);
            }else
            {
                string content = File.ReadAllText(adultsFile);
                Adults = JsonSerializer.Deserialize<List<Adult>>(content);

            }
           
        }

        public IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public async Task<Adult> addData(Adult adult)
        {
            adult.Id = Adults.Max(t => t.Id) + 1;
            Adults.Add(adult);
            string adultJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, adultJson);
            return adult;
        }

        public void SaveChanges(Person addAdult)
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public async Task<IList<Adult>> getAdults()
        {
            List<Adult> lis = new List<Adult>(Adults);
            return lis;
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult remove = Adults.First(t => t.Id == adultId);
            Adults.Remove(remove);
            string adultJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, adultJson);
        }

        public Adult get(int id)
        {
            return Adults.FirstOrDefault(t => t.Id == id);

        }

        public async Task<Adult> Update(Adult adult)
        {
            Adult toUpdate = Adults.First(t => t.Id == adult.Id);
            if (toUpdate == null) throw new Exception("Did not found Adult with id ");
            toUpdate.IsCompleted = adult.IsCompleted;
            toUpdate.Id = adult.Id;
            string adultJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, adultJson);
            return toUpdate;
        }

        private void Seed()
        {
            Adult[] ts =
            {
                new Adult()
                {
                    Id = 1,
                    JobTitle = "Do dishes",
                    IsCompleted = false
                },
                new Adult()
                {
                    Id = 2,
                    
                    JobTitle = "Walk the dog",
                    IsCompleted = false
                },
                new Adult()
                {
                    Id = 3,
                    
                    JobTitle = "Do DNP homework",
                    IsCompleted = true
                },
                new Adult()
                {
                    Id = 4,
                    
                    JobTitle = "Eat breakfast",
                    IsCompleted = false
                },
                new Adult()
                {
                    Id = 5,
                  
                    JobTitle = "Mow lawn",
                    IsCompleted = true
                },
            };
            Adults = ts.ToList();
        }
    }
}