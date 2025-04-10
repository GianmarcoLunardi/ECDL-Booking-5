using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2
{
    public class Program
    {
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
/*
 Video Sui Ruoli Asp-Net
  
 https://www.bing.com/videos/riverview/relatedvideo?&q=asp.net+identity+core+UI+complete+roles&&mid=1891A6B765F9D756B8651891A6B765F9D756B865&&mcid=4F37CE6367344352A49568CADF628F59&FORM=VRDGAR
*/