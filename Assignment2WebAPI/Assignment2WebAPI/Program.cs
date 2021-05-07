using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2WebAPI;
using Assignment2WebAPI.Persistance;
using Models;
using Assignment2WebAPI.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AdvancedTodoWebAPIDB {
    public class Program {
        public static void Main(string[] args) {
            using (CloudContext context = new CloudContext())

        CreateHostBuilder(args).Build().Run();
    }

    

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>(); 
            
            });
}
}