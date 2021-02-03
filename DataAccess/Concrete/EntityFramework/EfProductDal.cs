using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet:NuGet vasıtasıyla, başkaları tarafından hazırlanmış bileşenleri, paketleri projenize dahil edebilirsiniz.
    //Manage Nuget Packages ile EntityFrameworkCoreSqlServer indirdik.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext()) //using içine yazılan nesneler using bitince bellekten atılır.(Garbage Collector bellekten atar.)  
            {
                var addedEntity = context.Entry(entity); //referansı yakala
                addedEntity.State = EntityState.Added; //o eklenecek bir nesne
                context.SaveChanges(); //ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())  
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges(); 
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //ternary operatör(?:)
                return filter == null
                    ? context.Set<Product>().ToList() //filtre null ise products tablosuna yerleş ve oradaki tüm datayı bir listeye çevir.(Select * from Products)
                    : context.Set<Product>().Where(filter).ToList();  //null değilse filtrelenen verileri bir listeye çevir
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
