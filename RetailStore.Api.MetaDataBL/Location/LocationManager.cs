using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Location.Models;
using RetailStore.Api.MetaDataBL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Location
{
    public class LocationManager : ILocationManager
    {
        private readonly MetaDataDBContext metaDataDBContext;
        public LocationManager(MetaDataDBContext metaDataDBContext)
        {
            this.metaDataDBContext = metaDataDBContext;
        }

        public async Task<List<LocationModel>> ListLocation()
        {
            return await this.metaDataDBContext.LocationModel.ToListAsync();
        }

        public async Task<LocationModel> OpenLocation(long locationId)
        {
            return await this.metaDataDBContext.LocationModel.Where(x => x.LocationId == locationId)
                .Include(c => c.DepartmentModel).FirstOrDefaultAsync();
        }

        public async Task<bool> SubmitLocation(LocationModel locationModel)
        {
            if (locationModel.LocationId == 0)
            {
                await this.metaDataDBContext.AddAsync(locationModel);
            }
            else
            {
                this.metaDataDBContext.Update(locationModel);
            }
            return await this.metaDataDBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLocation(LocationModel locationModel)
        {
            var result = this.metaDataDBContext.Remove(locationModel);
            return await Task.FromResult(true);
        }
    }
}
