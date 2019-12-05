using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Repository;
using RetailStore.Api.MetaDataBL.SkuDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.SkuDetails
{
    public class SkuDetailsManager : ISkuDetailsManager
    {
        private readonly MetaDataDBContext metaDataDBContext;

        public SkuDetailsManager(MetaDataDBContext metaDataDBContext)
        {
            this.metaDataDBContext = metaDataDBContext;
        }

        public async Task<List<SkuDetailsModel>> ListSkuDetails(long locationId, long departmentId, long categoryId, long subCategoryId)
        {
            return await this.metaDataDBContext.SkuDetailsModel
                .Where(x => x.LocationId == locationId && x.DepartmentId == departmentId
                && x.CategoryId == categoryId && x.SubcategoryId == subCategoryId)
                .Include(c => c.LocationModel).Include(a => a.DepartmentModel).Include(b => b.CategoryModel).Include(d => d.SubcategoryModel).ToListAsync();
        }
    }
}
