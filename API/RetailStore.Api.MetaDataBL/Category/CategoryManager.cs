using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Category.Models;
using RetailStore.Api.MetaDataBL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly MetaDataDBContext metaDataDBContext;
        public CategoryManager(MetaDataDBContext metaDataDBContext)
        {
            this.metaDataDBContext = metaDataDBContext;
        }

        public async Task<List<CategoryModel>> ListCategory()
        {
            return await this.metaDataDBContext.CategoryModel.ToListAsync();
        }

        public async Task<CategoryModel> OpenCategory(long categoryId)
        {
            return await this.metaDataDBContext.CategoryModel.Where(x => x.CategoryId == categoryId)
                .Include(c => c.SubcategoryModel).FirstOrDefaultAsync();
        }

        public async Task<bool> SubmitCategory(CategoryModel categoryModel)
        {
            if (categoryModel.CategoryId == 0)
            {
                await this.metaDataDBContext.AddAsync(categoryModel);
            }
            else
            {
                this.metaDataDBContext.Update(categoryModel);
            }
            return await this.metaDataDBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategory(CategoryModel categoryModel)
        {
            var result = this.metaDataDBContext.Remove(categoryModel);
            return await Task.FromResult(true);
        }

        public async Task<List<CategoryModel>> ListCategoryBasedonDepartment(long departmentId)
        {
            return await this.metaDataDBContext.CategoryModel.Where(x => x.DepartmentId == departmentId).ToListAsync();
        }
    }
}
