using RetailStore.Api.MetaDataBL.Department.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Department
{
    public interface IDepartmentManager
    {
        Task<List<DepartmentModel>> ListDepartment();

        Task<DepartmentModel> OpenDepartment(long departmentId);

        Task<bool> SubmitDepartment(DepartmentModel departmentModel);

        Task<bool> DeleteDepartment(DepartmentModel departmentModel);

        Task<List<DepartmentModel>> ListDepartmentBasedonLocation(long locationId);


    }
}
