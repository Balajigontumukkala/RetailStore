using RetailStore.Api.MetaDataBL.Category.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RetailStore.Api.MetaDataBL.Department.Models
{
    [Table("Department",Schema ="metadata")]
    public class DepartmentModel
    {
        [Key]
        public long DepartmentId { get; set; }

        public long? LocationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CategoryModel> CategoryModel { get; set; }
    }
}
