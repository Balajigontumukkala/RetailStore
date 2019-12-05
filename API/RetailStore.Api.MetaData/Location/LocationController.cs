using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.Location;
using RetailStore.Api.MetaDataBL.Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.Location
{
    public class LocationController : MetaDataBaseController
    {
        private readonly ILocationManager locationManager;
        public LocationController(ILocationManager locationManager)
        {
            this.locationManager = locationManager;
        }

        [HttpGet("ListLocation")]
        [ActionName("ListLocation")]
        public async Task<List<LocationModel>> ListLocationAsync()
        {
            return await this.locationManager.ListLocation();
        }

        [HttpGet("OpenLocation")]
        [ActionName("OpenLocation")]
        public async Task<LocationModel> OpenLocationAsync(int locationId)
        {
            return await this.locationManager.OpenLocation(locationId);
        }

        [HttpPost("SubmitLocation")]
        [ActionName("SubmitLocation")]
        public async Task<bool> SubmitLocationAsync([FromBody]LocationModel locationModel)
        {
            return await this.locationManager.SubmitLocation(locationModel);
        }

        [HttpGet("DeleteLocation")]
        [ActionName("DeleteLocation")]
        public async Task<bool> DeleteLocationAsync(LocationModel locationModel)
        {
            return await this.locationManager.DeleteLocation(locationModel);
        }
    }
}
