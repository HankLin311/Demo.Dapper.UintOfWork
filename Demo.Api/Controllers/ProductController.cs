using Demo.Common.Do;
using Demo.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase

    {
        IUnitDbContext _unitDbContext;
        public ProductController(IUnitDbContext unitDbContext) 
        {
            _unitDbContext = unitDbContext;
        }

        [HttpGet]
        public ProductDo GetProdutById() 
        {
            ProductDo productDo = new()
            {
                product_id = "XXXXXXXXXX1"
            };

           var result = _unitDbContext.ProductRepository.GetById(productDo);
            _unitDbContext.SaveChange();

            return result;
        }
    }
}
