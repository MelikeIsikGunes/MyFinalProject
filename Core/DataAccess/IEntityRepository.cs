using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess  //evrensel kodları core katmanına ekliyoruz - EVRENSEL KATMAN
    // **Core katmanı diğer katmanları referans almaz
{
    //generic constraint- jenerik kısıt
    //class: Referans tip
    //IEntity: T ya IEntity olmalı ya da IEntity implemente eden bir nesne olmalı
    //new: T new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new() //T hangi entity verirsek. 
    {//Veritabanında yapacağımız operasyonları içeren Interface
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //filtreleme işlemlerini tek bir metotta yapar. null olduğu için filtre vermek zorunda değiliz.
        T Get(Expression<Func<T, bool>> filter); //tek bir veri getirmek için. Detaylara gitmek için kullanılabilir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);    }
}
