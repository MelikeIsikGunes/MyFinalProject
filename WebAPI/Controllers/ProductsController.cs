using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   //ATTRIBUTE
    public class ProductsController : ControllerBase
    {
        //Loosely coupled - Gevşek bağlılık
        //IoC Container - Inversion od Control - Değişimin Kontrolü
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] 
        public IActionResult GetAll() // localhost:44347/api/products/getall
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);  //postmanda 200 OK
            }
            return BadRequest(result); //postmanda 400 Bad Request
        }

        [HttpGet("getbyid")] 
        public IActionResult GetById(int id) // localhost:44347/api/products/getbyid?id=1
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
