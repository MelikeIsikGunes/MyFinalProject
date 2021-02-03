using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface operasyonları default publictir.
    public interface IProductDal : IEntityRepository<Product> //Dal=Data Access Layer
    {
        
    
    }
}
