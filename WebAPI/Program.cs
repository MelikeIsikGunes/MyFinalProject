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
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  //burayý biz ekledik (kendi altyapýsýný kullanmasýn fabrika olarak Autofac kullansýn)
                .ConfigureContainer<ContainerBuilder>(builder =>                 //burayý biz ekledik
                {
                    builder.RegisterModule(new AutofacBusinessModule());         //burayý biz ekledik (.Net Core yerine baþka bir(kendi oluþturduðumuz) IOC Container kullanmak istiyorum)
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
