using RetailStore.Api.MetaDataBL.Department.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Api.MetaDataBL.Location.Models
{
    [Table("Location",Schema ="metadata")]
    public class LocationModel
    {
        [Key]
        public long LocationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<DepartmentModel> DepartmentModel { get; set; }
    }
}
