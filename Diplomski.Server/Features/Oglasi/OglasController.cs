using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Infrastructure;
using Diplomski.Server.Features.Oglasi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Diplomski.Server.Features.Oglasi.Models;
using Diplomski.Server.Infrastructure.Extensions;
using static Diplomski.Server.Infrastructure.WebConstants;
using Diplomski.Server.Infrastructure.Services;

namespace Diplomski.Server.Features.Oglasi
{
   
    public class OglasController : ApiController
    {

        private readonly IOglasService oglasi;
        private readonly ICurrentUserService currentUser;

        public OglasController(IOglasService oglasi, ICurrentUserService currentUser)
        {
            this.oglasi = oglasi;
            this.currentUser = currentUser;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<OglasListingServiceModel>> MyOglas()
        {
            var userId = this.currentUser.GetId();
            return await this.oglasi.OglasByUser(userId);

        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<ListAllOglasModel>> GetOglasi()
        {
            return await this.oglasi.GetOglasi();
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<OglasDetailsServiceModel>> Details(int id)
        {
            var oglas = await this.oglasi.Details(id);

            oglas.Pitanja = await this.oglasi.GetPitanjaByOglasId(id);

            return oglas;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateOglasRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.oglasi.Create(model.Naziv, model.IndustrijaId, model.Opis, userId);

            if (model.Pitanja.Count != 0)
            {
                var res = await this.oglasi.CreatePitanja(id, model.Pitanja);
            }

            return Created(nameof(Create), id);
        }

        [HttpGet]
        [Authorize]
        [Route("myobavijesti")]
        public async Task<IEnumerable<ObavijestDetailsModel>> GetObavijesti()
        {
            var userId = this.currentUser.GetId();
            return await this.oglasi.GetObavijesti(userId);

        }

        [HttpGet]
        [Authorize]
        [Route("noveobavijesti")]
        public async Task<int> GetBrojNovihObavijesti()
        {
            var userId = this.currentUser.GetId();
            return await this.oglasi.GetBrojNovihObavijesti(userId);
        }

        [HttpPost]
        [Authorize]
        [Route("posaljiobavijest")]
        public async Task<ActionResult> CreateObavijest(CreateObavijestModel model)
        {
            var userId = this.currentUser.GetId();
            var obavijestId = await this.oglasi.CreateObavijest(userId, model.IdOglas, model.Naslov, model.Tekst);

            var res = await this.oglasi.CreateKandidatObavijest(obavijestId, model.KandidatIds);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Update(int id, UpdateOglasRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.oglasi.Update(id, model.Naziv, model.IndustrijaId, model.Opis, userId);

            if (result.Failure)
            {
                return BadRequest();
            }

            if (model.NovaPitanja.Count != 0)
            {
                var res = await this.oglasi.CreatePitanja(id, model.NovaPitanja);
            }

            if (model.ObrisanaPitanjaIds.Count != 0)
            {
                var res = await this.oglasi.DeletePitanja(model.ObrisanaPitanjaIds);
            }

            return this.Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var result = await this.oglasi.Delete(id, userId);

            if (result.Failure)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("{oglasId}/kandidati")]
        public async Task<IEnumerable<KandidatDetailsModel>> GetPrijave(int oglasId)
        {
            var userId = this.currentUser.GetId();

            var kandidati = await this.oglasi.GetKandidatiByOglasId(oglasId, userId);

           
            return kandidati;
        }

        [HttpGet]        
        [Route("{poslodavacId}/poslodavac")]
        public async Task<PoslodavacDetailsModel> GetPoslodavac(string poslodavacId)
        {          
            var poslodavac = await this.oglasi.GetPoslodavac(poslodavacId);

            return poslodavac;
        }
       

        [HttpGet]
        [Authorize]
        [Route("{oglasId}/obavijest")]
        public async Task<IEnumerable<KandidatDetailsModel>> GetKandidatiForObavijest(int oglasId)
        {
            var userId = this.currentUser.GetId();
            var kandidati = await this.oglasi.GetKandidatiByPoslodavacId(userId, oglasId);

            return kandidati;
        }

        [HttpDelete]
        [Authorize]
        [Route("{oglasId}/arhiva")]
        public async Task<ActionResult> ArhivirajOglas(int oglasId)
        {
            var userId = this.currentUser.GetId();

            var result = await this.oglasi.Arhiviraj(oglasId, userId);

            if (result.Failure)
            {
                return BadRequest();
            }
            return Ok();
        }

       
    }
}
