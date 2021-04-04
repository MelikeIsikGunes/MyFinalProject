﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //field oluşturmak - defaultu private
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Encrytion, Hashing, Salting
        //örneğin parolaları db'de açık tutmak yerine şifreleme yöntemi ile tutmak(hashlemek)
        
        [SecuredOperation("product.add, admin")]  //Yetkilendirme kontrolü.  product.add -> claim
        [ValidationAspect(typeof( ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")] //yeni ürün eklenince Get ile başlayanları bellekten sil
        public IResult Add(Product product)
        {
            //eklemeden önce kuralları buraya yazarız-business codes (Örn: Bir kategoride max 10 ürün olsun)
            //validation-doğrulama-->nesnenin yapısıyla ilgili olan şeyler (Örn: Ürün ismi min 2 karakter  olsun)          

            
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());
            //iş kurallarında hata oluşmazsa result null olur.

            if (result!=null) //kurala uymayan bir durum oluşmuşsa
            {
                return result;
            }
            _productDal.Add(product);

             return new SuccessResult(Messages.ProductAdded);
          
        }

        [CacheAspect] //key,value
        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //if kodları

            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        [CacheAspect]
        [PerformanceAspect(5)] //bu metotun çalışması 5 sn geçerse beni uyar
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")] //ürün güncellendiği zaman IProductService'deki tüm Get olan metotları bellekten sil
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10) //Bir kategoride en fazla 10 ürün olabilir
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)  //private-bu metod sadece bu class içinde kullanılsın. İş kuralı parçacığı
        {//Bir kategoride en fazla 10 ürün olabilir
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count; //Select count(*) from products where categoryid=x
            if (result >= 15) 
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {//Aynı isimde ürün eklenemesin
            var result = _productDal.GetAll(p=>p.ProductName==productName).Any(); //Any-Var mı? bool
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        } 

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if(product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}
