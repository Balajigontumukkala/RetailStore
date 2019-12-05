using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.Department;
using RetailStore.Api.MetaDataBL.Department.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.Department
{
    public class DepartmentController : MetaDataBaseController
    {
        private readonly IDepartmentManager departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            this.departmentManager = departmentManager;
        }

        [HttpGet("ListDepartment")]
        [ActionName("ListDepartment")]
        public async Task<List<DepartmentModel>> ListDepartmentAsync()
        {
            return await this.departmentManager.ListDepartment();
        }

        [HttpGet("OpenDepartment")]
        [ActionName("OpenDepartment")]
        public async Task<DepartmentModel> OpenDepartmentAsync(int departmentId)
        {
            return await this.departmentManager.OpenDepartment(departmentId);
        }

        [HttpPost("SubmitDepartment")]
        [ActionName("SubmitDepartment")]
        public async Task<bool> SubmitDepartmentAsync([FromBody]DepartmentModel departmentModel)
        {
            return await this.departmentManager.SubmitDepartment(departmentModel);
        }

        [HttpGet("DeleteDepartment")]
        [ActionName("DeleteDepartment")]
        public async Task<bool> DeleteDepartmentAsync(DepartmentModel departmentModel)
        {
            return await this.departmentManager.DeleteDepartment(departmentModel);
        }

        [HttpGet("ListDepartmentBasedonLocation")]
        [ActionName("ListDepartmentBasedonLocation")]
        public async Task<List<DepartmentModel>> ListDepartmentBasedonLocationAsync(int locationId)
        {
            return await this.departmentManager.ListDepartmentBasedonLocation(locationId);
        }
    }
}
