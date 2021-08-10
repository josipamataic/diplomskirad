using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Identity;
using Diplomski.Server.Features.Identity.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identity;
        private readonly AppSettings appSettings;
        private readonly ICurrentUserService currentUser;

        public IdentityController(UserManager<User> userManager, IIdentityService identity, IOptions<AppSettings> appSettings,
            ICurrentUserService currentUser)
        {
            this.userManager = userManager;
            this.identity = identity;
            this.appSettings = appSettings.Value;
            this.currentUser = currentUser;

        }


        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                

            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await userManager.AddToRoleAsync(user, model.Uloga);
            return Ok();
            
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = identity.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret);
            var role = await userManager.GetRolesAsync(user);

            return new LoginResponseModel
            {
                Token = token,
                Role = role.FirstOrDefault()
            };                   


        }


     
    }
}
