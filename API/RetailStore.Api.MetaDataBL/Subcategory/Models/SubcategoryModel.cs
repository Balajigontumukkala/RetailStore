using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Subcategory.Models
{
    [Table("Subcategory", Schema ="metadata")]
    public class SubcategoryModel
    {
        [Key]
        public long SubcategoryId { get; set; }

        public long? CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
