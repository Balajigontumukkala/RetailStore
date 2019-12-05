using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.SkuDetails;
using RetailStore.Api.MetaDataBL.SkuDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.SkuDetails
{
    public class SkuDetailsController : MetaDataBaseController
    {
        private readonly ISkuDetailsManager skuDetailsManager;
        public SkuDetailsController(ISkuDetailsManager skuDetailsManager)
        {
            this.skuDetailsManager = skuDetailsManager;
        }

        [HttpGet("ListSkuDetails")]
        [ActionName("ListSkuDetails")]
        public async Task<List<SkuDetailsModel>> ListSkuDetailsAsync(long locationId, long departmentId, long categoryId, long subCategoryId)
        {
            return await this.skuDetailsManager.ListSkuDetails(locationId, departmentId, categoryId, subCategoryId);
        }
    }
}
