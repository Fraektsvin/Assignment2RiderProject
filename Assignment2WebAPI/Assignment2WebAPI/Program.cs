using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2WebAPI;
using Models;
using Assignment2WebAPI.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AdvancedTodoWebAPIDB {
    public class Program {
        public static void Main(string[] args) {
       
    



         var TodoContext = new TodoContext();
         Adult adult = new Adult( "gg", false, 1);
            
            Console.WriteLine(adult);
        CreateHostBuilder(args).Build().Run();
    }

    

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>(); 
            
            });
}
}