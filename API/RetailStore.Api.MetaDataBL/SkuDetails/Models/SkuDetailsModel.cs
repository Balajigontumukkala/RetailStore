using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RetailStore.Api.MetaDataBL.Category.Models;
using RetailStore.Api.MetaDataBL.Department.Models;
using RetailStore.Api.MetaDataBL.Location.Models;
using RetailStore.Api.MetaDataBL.Subcategory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.SkuDetails.Models
{
    [Table("SkuDetails",Schema ="sku")]
    public class SkuDetailsModel
    {
        [Key]
        public long SkuId { get; set; }

        public string SkuName { get; set; }

        public long LocationId { get; set; }

        public LocationModel LocationModel { get; set; }

        public long DepartmentId { get; set; }

        public DepartmentModel DepartmentModel { get; set; }

        public long CategoryId { get; set; }

        public CategoryModel CategoryModel { get; set; }

        public long SubcategoryId { get; set; }

        public SubcategoryModel SubcategoryModel { get; set; }
    }
}
