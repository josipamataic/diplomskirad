using Diplomski.Server.Features.Oglasi;
using Diplomski.Server.Features.Oglasi.Models;
using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public class PoslodavacProfilController : ApiController
    {
        private readonly IPoslodavacProfilService poslodavacProfil;
        private readonly IOglasService oglasi;
        private readonly ICurrentUserService currentUser;

        public PoslodavacProfilController(ICurrentUserService currentUser, IPoslodavacProfilService poslodavacProfil, IOglasService oglasi)
        {
            this.currentUser = currentUser;
            this.poslodavacProfil = poslodavacProfil;
            this.oglasi = oglasi;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PoslodavacProfilServiceModel>> MyProfil()
            => await this.poslodavacProfil.MyProfil(this.currentUser.GetId());

        [HttpGet]        
        [Route("poslodavci")]
        public async Task<IEnumerable<ListPoslodavacProfil>> GetPoslodavci()
        {
            return await this.poslodavacProfil.GetPoslodavci();
        }

        [HttpGet]
        [Route("{poslodavacId}/oglasi")]
        public async Task<IEnumerable<ListAllOglasModel>> GetOglasiByPoslodavac(string poslodavacId)
        {
            return await this.oglasi.GetOglasiByPoslodavac(poslodavacId);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdatePoslodavacProfilRequestModel model)
        {
            var userId = this.currentUser.GetId();
           
            var result = await this.poslodavacProfil.Update(userId, model.UserName, model.Email, model.IndustrijaId, model.NazivFirme, model.Kontakt,
                model.Opis, model.Zemlja, model.PrivatniProfil);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}
