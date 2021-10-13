using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntroductionToAspNetCoreMvc
{
    public class Program
    {
        //ulazna toèka u našu aplikaciju
        //aplikacija se pokreæe kao standardna konzolna aplikacija, a u Main metodi dolazi do konfiguriranja ASP.NET Core i 
        //aplikacija postaje ASP.NET Core web aplikacija
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
