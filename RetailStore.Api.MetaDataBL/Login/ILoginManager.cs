using RetailStore.Api.MetaDataBL.Login.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Login
{
    public interface ILoginManager
    {
        Task<LoginModel> LoginUserAsync(LoginModel loginModel);
    }
}
