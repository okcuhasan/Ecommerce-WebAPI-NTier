﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Categories.RequestModels;
using Project.WebAPI.Models.Categories.ResponseModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager) 
        {
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel category)
        {
            Category c = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
            };

            string result = _categoryManager.Add(c);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponseModel> categories = _categoryManager.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                CategoryID = x.ID,
            }).ToList();


            return Ok(categories);
        }
    }
}
