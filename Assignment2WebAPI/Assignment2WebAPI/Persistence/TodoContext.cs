using Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using Assignment2WebAPI.Data;

namespace Assignment2WebAPI.Persistence
{
    public class TodoContext : IAdult
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public TodoContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        public IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void addData(Adult adult)
        {
            adult.Id = Adults.Max(t => t.Id) + 1;
            Adults.Add(adult);
            string adultJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, adultJson);
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

        public IList<Adult> getAdults()
        {
            List<Adult> lis = new List<Adult>(Adults);
            return lis;
        }
        public void RemoveAdult(int adultId)
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
        public void Update(Adult adult)
        {

            Adult toUpdate = Adults.First(t => t.Id == adult.Id);
            toUpdate.IsCompleted = adult.IsCompleted;
            toUpdate.Id = adult.Id;
            SaveChanges(adult);
        }
    }
}