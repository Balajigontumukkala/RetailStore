using RetailStore.Api.MetaDataBL.Location.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Location
{
    public interface ILocationManager
    {
        Task<List<LocationModel>> ListLocation();

        Task<LocationModel> OpenLocation(long locationId);

        Task<bool> SubmitLocation(LocationModel locationModel);

        Task<bool> DeleteLocation(LocationModel locationModel);

    }
}
