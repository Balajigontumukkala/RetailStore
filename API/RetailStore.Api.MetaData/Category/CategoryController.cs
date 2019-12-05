using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.Category;
using RetailStore.Api.MetaDataBL.Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.Category
{
    public class CategoryController : MetaDataBaseController
    {
        private readonly ICategoryManager categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet("ListCategory")]
        [ActionName("ListCategory")]
        public async Task<List<CategoryModel>> ListCategoryAsync()
        {
            return await this.categoryManager.ListCategory();
        }

        [HttpGet("OpenCategory")]
        [ActionName("OpenCategory")]
        public async Task<CategoryModel> OpenCategoryAsync(long categoryId)
        {
            return await this.categoryManager.OpenCategory(categoryId);
        }

        [HttpPost("SubmitCategory")]
        [ActionName("SubmitCategory")]
        public async Task<bool> SubmitCategoryAsync([FromBody]CategoryModel categoryModel)
        {
            return await this.categoryManager.SubmitCategory(categoryModel);
        }

        [HttpGet("DeleteCategory")]
        [ActionName("DeleteCategory")]
        public async Task<bool> DeleteCategoryAsync(CategoryModel categoryModel)
        {
            return await this.categoryManager.DeleteCategory(categoryModel);
        }

        [HttpGet("ListCategoryBasedonDepartment")]
        [ActionName("ListCategoryBasedonDepartment")]
        public async Task<List<CategoryModel>> ListCategoryBasedonDepartmentAsync(long departmentId)
        {
            return await this.categoryManager.ListCategoryBasedonDepartment(departmentId);
        }
    }
}
