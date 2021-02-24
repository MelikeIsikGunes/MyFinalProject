using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //Constants-Sabitler- Bu proje için sabit olan şeyler
    public static class Messages //sürekli bunu newlememek için static
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Sistem bakımda"; //Bakım Zamanı
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
    }
}
