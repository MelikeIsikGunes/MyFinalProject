using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface operasyonları default publictir.
    public interface IProductDal  //Dal=Data Access Layer
    {//Veritabanında yapacağımız operasyonları içeren Interface
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId); //ürünleri kategoriye göre filtrele 
    
    }
}
