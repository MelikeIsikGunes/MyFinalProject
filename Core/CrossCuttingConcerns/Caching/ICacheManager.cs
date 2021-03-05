using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{ //Farklı cache alternatifleri kullanılabilir. Bu yüzden bütün alternatiflerin interface'i olacak
    public interface ICacheManager
    {
        T Get<T>(string key);  //generic metod
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //cache'te var mı?
        void Remove(string key); //cache'ten uçurma
        void RemoveByPattern(string pattern); //Örn: Get ile başlayanları uçur


    }
}
