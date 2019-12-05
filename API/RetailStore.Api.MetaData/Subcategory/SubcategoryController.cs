using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.Subcategory;
using RetailStore.Api.MetaDataBL.Subcategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.Subcategory
{
    public class SubcategoryController : MetaDataBaseController
    {
        private readonly ISubcategoryManager subcategoryManager;
        public SubcategoryController(ISubcategoryManager subcategoryManager)
        {
            this.subcategoryManager = subcategoryManager;
        }

        [HttpGet("ListSubcategory")]
        [ActionName("ListSubcategory")]
        public async Task<List<SubcategoryModel>> ListSubcategoryAsync()
        {
            return await this.subcategoryManager.ListSubcategory();
        }

        [HttpGet("OpenSubcategory")]
        [ActionName("OpenSubcategory")]
        public async Task<SubcategoryModel> OpenSubcategoryAsync(long subCategoryId)
        {
            return await this.subcategoryManager.OpenSubcategory(subCategoryId);
        }

        [HttpPost("SubmitSubcategory")]
        [ActionName("SubmitSubcategory")]
        public async Task<bool> SubmitSubcategoryAsync([FromBody]SubcategoryModel subCategoryModel)
        {
            return await this.subcategoryManager.SubmitSubcategory(subCategoryModel);
        }

        [HttpGet("DeleteSubcategory")]
        [ActionName("DeleteSubcategory")]
        public async Task<bool> DeleteSubcategoryAsync(SubcategoryModel subCategoryModel)
        {
            return await this.subcategoryManager.DeleteSubcategory(subCategoryModel);
        }

        [HttpGet("ListSubcategoryBasedonCategory")]
        [ActionName("ListSubcategoryBasedonCategory")]
        public async Task<List<SubcategoryModel>> ListSubcategoryBasedonCategoryAsync(long categoryId)
        {
            return await this.subcategoryManager.ListSubcategoryBasedonCategory(categoryId);
        }
    }
}
