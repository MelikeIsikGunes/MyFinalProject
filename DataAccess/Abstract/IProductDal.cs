using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface operasyonları default publictir.
    public interface IProductDal : IEntityRepository<Product> //Dal=Data Access Layer
    {
        List<ProductDetailDto> GetProductDetails();
    
    }
}
