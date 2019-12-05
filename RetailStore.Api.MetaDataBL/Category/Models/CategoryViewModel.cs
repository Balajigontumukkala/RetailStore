using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Category.Models
{
    [Table("Category", Schema = "metadata")]
    public class CategoryViewModel
    {
        [Key]
        public long CategoryId { get; set; }

        public long? DepartmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
