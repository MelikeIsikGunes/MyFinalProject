using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity //public yaptığımız zaman bu classa diğer katmanlar da ulaşabilir. (Business(ürünü kontrol edecek), DataAccess(ürünü ekleyecek),ConsoleUI(ürünü gösterecek))
    { //bir classın defaultu internal'dir. Sadece Entities erişebilir.

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}
