using RetailStore.Api.MetaDataBL.SkuDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.SkuDetails
{
    public interface ISkuDetailsManager
    {
        Task<List<SkuDetailsModel>> ListSkuDetails(long locationId, long departmentId, long categoryId, long subCategoryId);
    }
}
