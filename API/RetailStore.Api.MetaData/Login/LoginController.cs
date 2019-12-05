using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.MetaDataBL.Login;
using RetailStore.Api.MetaDataBL.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaData.Login
{
    public class LoginController : MetaDataBaseController
    {
        private readonly ILoginManager iLoginManager;


        public LoginController(ILoginManager iLoginManager)
        {
            this.iLoginManager = iLoginManager;
        }

        [HttpPost("LoginUser")]
        [ActionName("LoginUser")]
        public async Task<LoginModel> LoginUserAsync([FromBody] LoginModel loginModel)
        {
            return await this.iLoginManager.LoginUserAsync(loginModel);
        }
    }
}
