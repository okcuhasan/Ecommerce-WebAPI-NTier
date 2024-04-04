using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Products.RequestModels;
using Project.WebAPI.Models.Products.ResponseModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            var product = new Product
            {
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
            };

            string result = _productManager.Add(product);

            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProduct(int categoryID)
        {
            var p = _productManager.Where(x => x.CategoryID == categoryID)
                .Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();

            return Ok(p);
        }

    }
}
