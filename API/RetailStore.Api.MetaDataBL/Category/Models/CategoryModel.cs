using RetailStore.Api.MetaDataBL.Subcategory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RetailStore.Api.MetaDataBL.Category.Models
{
    [Table("Category", Schema ="metadata")]
    public class CategoryModel
    {
        [Key]
        public long CategoryId { get; set; }

        public long? DepartmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<SubcategoryModel> SubcategoryModel { get; set; }
    }
}
