using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext //EF ile beraber gelen base sınıf
    {
        //override yaz boşluk bırak on yaz:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bu metot projemizin hangi veritabanıyla ilişkili olduğunu belirteceğimiz metot.
        {
            //Sql Server kullanacağız
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //bağlanıyoruz 
        }

        public DbSet<Product> Products { get; set; } //projedeki Product nesnesi veritabanındaki Products tablosudur
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
