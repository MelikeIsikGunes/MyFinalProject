using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID'in o harfi
    //Open Closed Principle : Yaptığın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiçbir koduna dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            //foreach (var product in productManager.GetAll())  //tüm ürünler
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //foreach (var product in productManager.GetAllByCategoryId(2)) //2 nolu kategorideki ürünler
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            foreach (var product in productManager.GetByUnitPrice(40,100)) //fiyatı min 40 max 100 olan ürünler
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
