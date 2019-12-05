using RetailStore.Api.MetaDataBL.Subcategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Subcategory
{
    public interface ISubcategoryManager
    {

        Task<List<SubcategoryModel>> ListSubcategory();

        Task<SubcategoryModel> OpenSubcategory(long subCategoryId);

        Task<bool> SubmitSubcategory(SubcategoryModel subCategoryModel);

        Task<bool> DeleteSubcategory(SubcategoryModel subCategoryModel);

        Task<List<SubcategoryModel>> ListSubcategoryBasedonCategory(long categoryId);
    }
}
