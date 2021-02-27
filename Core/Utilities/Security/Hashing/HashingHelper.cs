using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    { //Hash oluşturma ve Doğrulama işlemleri
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //verilen şifrenin hash ve salt değerini oluşturan yapı
        {//out - dışarıya gönderilecek veri

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //Salting. Her kullanıcı için bir key oluşturulur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Hashing. stringi byte çevirdik
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //hash doğrula
        {//kullanıcı tekrar sisteme girmeye çalışırken şifreyi tekrar hashleyip db'dekine eşit olup olmadığını kontrol ediyoruz(doğrulama)
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])  //yeniden hashlenen şifre != db'deki hashlenmiş şifre
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
