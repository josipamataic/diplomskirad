using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Identity.Models;
using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public class KandidatProfilController : ApiController
    {
        private readonly IKandidatProfilService kandidatProfil;
        private readonly ICurrentUserService currentUser;
        

        public KandidatProfilController(IKandidatProfilService kandidatProfil, ICurrentUserService currentUser)
        {
            this.kandidatProfil = kandidatProfil;
            this.currentUser = currentUser;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<KandidatProfilServiceModel>> MyProfil()
            => await this.kandidatProfil.MyProfil(this.currentUser.GetId());

        [HttpGet]
        [Authorize]
        [Route("kandidati")]
        public async Task<IEnumerable<KandidatProfilServiceModel>> GetKandidati()
        {
            return await this.kandidatProfil.GetKandidati();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateKandidatProfilRequestModel model) 
        {
            var userId = this.currentUser.GetId();

            var result = await this.kandidatProfil.Update(userId, model.UserName, model.Ime, model.Prezime, model.Email, model.BrojMobitela, 
                model.DatumRodenja, model.IndustrijaId, model.Obrazovanje, model.Zemlja, model.PrivatniProfil);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete()
        {
            var userId = this.currentUser.GetId();
            var result = await this.kandidatProfil.Delete(userId);

            if (result.Failure)
            {
                return BadRequest();
            }
            return Ok();

        }


        [HttpDelete]
        [Route("deleteuser")]
        public async Task<ActionResult> DeleteUser()
        {
            var userId = this.currentUser.GetId();
            var result = await this.kandidatProfil.DeleteUser(userId);

            if (result.Failure)
            {
                return BadRequest();
            }
            return Ok();

        }


        [HttpGet]
        [Route("industrije")]
        public async Task<List<IndustrijaListingModel>> Industrije()
        {
            return await this.kandidatProfil.GetIndustrije();
        }


    }
}
