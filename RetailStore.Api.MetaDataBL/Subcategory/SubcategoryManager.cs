using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Repository;
using RetailStore.Api.MetaDataBL.Subcategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Subcategory
{
    public class SubcategoryManager : ISubcategoryManager
    {
        private readonly MetaDataDBContext metaDataDBContext;
        public SubcategoryManager(MetaDataDBContext metaDataDBContext)
        {
            this.metaDataDBContext = metaDataDBContext;
        }

        public async Task<List<SubcategoryModel>> ListSubcategory()
        {
            return await this.metaDataDBContext.SubcategoryModel.ToListAsync();
        }

        public async Task<SubcategoryModel> OpenSubcategory(long subCategoryId)
        {
            return await this.metaDataDBContext.SubcategoryModel.Where(x => x.SubcategoryId == subCategoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> SubmitSubcategory(SubcategoryModel subCategoryModel)
        {
            if (subCategoryModel.SubcategoryId == 0)
            {
                await this.metaDataDBContext.AddAsync(subCategoryModel);
            }
            else
            {
                this.metaDataDBContext.Update(subCategoryModel);
            }
            return await this.metaDataDBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSubcategory(SubcategoryModel subCategoryModel)
        {
            var result = this.metaDataDBContext.Remove(subCategoryModel);
            return await Task.FromResult(true);
        }

        public async Task<List<SubcategoryModel>> ListSubcategoryBasedonCategory(long categoryId)
        {
            return await this.metaDataDBContext.SubcategoryModel.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
