using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Department.Models;
using RetailStore.Api.MetaDataBL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Department
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly MetaDataDBContext metaDataDBContext;
        public DepartmentManager(MetaDataDBContext metaDataDBContext)
        {
            this.metaDataDBContext = metaDataDBContext;
        }

        public async Task<List<DepartmentModel>> ListDepartment()
        {
            return await this.metaDataDBContext.DepartmentModel.ToListAsync();
        }

        public async Task<DepartmentModel> OpenDepartment(long departmentId)
        {
            return await this.metaDataDBContext.DepartmentModel.Where(x => x.DepartmentId == departmentId)
                .Include(c=>c.CategoryModel).FirstOrDefaultAsync();
        }

        public async Task<bool> SubmitDepartment(DepartmentModel departmentModel)
        {
            if (departmentModel.DepartmentId == 0)
            {
                await this.metaDataDBContext.AddAsync(departmentModel);
            }
            else
            {
                this.metaDataDBContext.Update(departmentModel);
            }
            return await this.metaDataDBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDepartment(DepartmentModel departmentModel)
        {
            var result = this.metaDataDBContext.Remove(departmentModel);
            return await Task.FromResult(true);
        }

        public async Task<List<DepartmentModel>> ListDepartmentBasedonLocation(long locationId)
        {
            return await this.metaDataDBContext.DepartmentModel.Where(x => x.LocationId == locationId).ToListAsync();
        }
    }
}
