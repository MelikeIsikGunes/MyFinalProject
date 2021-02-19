using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.AutoFac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  //buray� biz ekledik (kendi altyap�s�n� kullanmas�n fabrika olarak Autofac kullans�n)
                .ConfigureContainer<ContainerBuilder>(builder =>                 //buray� biz ekledik
                {
                    builder.RegisterModule(new AutofacBusinessModule());         //buray� biz ekledik (.Net Core yerine ba�ka bir(kendi olu�turdu�umuz) IOC Container kullanmak istiyorum)
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
