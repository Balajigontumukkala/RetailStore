using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Department.Models
{
    [Table("Department", Schema = "metadata")]
    public class DepartmentViewModel
    {
        [Key]
        public long DepartmentId { get; set; }

        public long? LocationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
