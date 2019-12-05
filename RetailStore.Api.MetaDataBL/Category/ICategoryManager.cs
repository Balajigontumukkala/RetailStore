using RetailStore.Api.MetaDataBL.Category.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Category
{
    public interface ICategoryManager
    {
        Task<List<CategoryModel>> ListCategory();

        Task<CategoryModel> OpenCategory(long categoryId);

        Task<bool> SubmitCategory(CategoryModel categoryModel);

        Task<bool> DeleteCategory(CategoryModel categoryModel);

        Task<List<CategoryModel>> ListCategoryBasedonDepartment(long departmentId);



    }
}
