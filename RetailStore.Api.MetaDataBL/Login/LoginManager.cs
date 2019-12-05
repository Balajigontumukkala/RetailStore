using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RetailStore.Api.MetaDataBL.Login.Models;
using RetailStore.ClientConfiguration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Api.MetaDataBL.Login
{
    public class LoginManager : ILoginManager
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginModel> LoginUserAsync(LoginModel loginModel)
        {
            var appUser = await this.userManager.FindByEmailAsync(loginModel.Email);
            var signInResult = await signInManager.CheckPasswordSignInAsync(appUser, loginModel.Password, false);
            var token = string.Empty;
            if (signInResult.Succeeded)
            {
                var key = Encoding.ASCII.GetBytes(ClientConfiguration.ClientConfiguration.ClientSettings.Token.Key);
                var JWTToken = new JwtSecurityToken(
                    issuer: ClientConfiguration.ClientConfiguration.ClientSettings.Token.Issuer,
                    audience: ClientConfiguration.ClientConfiguration.ClientSettings.Token.Audience,
                    claims: GetUserClaims(loginModel),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(ClientConfiguration.ClientConfiguration.ClientSettings.Token.Lifetime)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    );
                token = new JwtSecurityTokenHandler().WriteToken(JWTToken);
                if (token != null)
                {
                    loginModel.Token = token;
                    loginModel.Password = "";
                    loginModel.Email = "";
                    this.httpContextAccessor.HttpContext.Session.SetString("UserToken", token);
                }
            }
            return loginModel;
        }

        //Using hard coded collection list as Data Store for demo. In reality, User data comes from Database or some other Data Source - JRozario
        private IEnumerable<Claim> GetUserClaims(LoginModel loginModel)
        {
            IEnumerable<Claim> claims = new Claim[]
                    {
                    new Claim("Email", loginModel.Email)
                    //new Claim("EMAILID", user.EMAILID),
                    //new Claim("PHONE", user.PHONE),
                    //new Claim("ACCESS_LEVEL", user.ACCESS_LEVEL.ToUpper()),
                    //new Claim("READ_ONLY", user.READ_ONLY.ToUpper())
                    };
            return claims;
        }
    }
}
