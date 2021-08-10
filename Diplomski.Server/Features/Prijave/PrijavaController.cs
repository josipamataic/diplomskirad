using Diplomski.Server.Data;
using Diplomski.Server.Features.Prijave.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Diplomski.Server.Infrastructure.WebConstants;

namespace Diplomski.Server.Features.Prijave
{
   // [Authorize(Roles = "Kandidat")]
    public class PrijavaController : ApiController
    {
        private readonly IPrijavaService prijave;
        private readonly ICurrentUserService currentUser;


        public PrijavaController(IPrijavaService prijave, ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.prijave = prijave;
          
        }

        [HttpPost]        
        public async Task<ActionResult> Create(CreatePrijavaModel model)
        {
            var userId = this.currentUser.GetId();          

            var prijavaId = await this.prijave.Create(model.OglasId, userId);

            if(prijavaId == 0)
            {
                return BadRequest();
            }
            
            if(model.Odgovori.Count > 0)
            {
                var result = await this.prijave.CreateOdgovori(userId, model.OglasId, prijavaId, model.Odgovori);
            }                

            return Ok();
          
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFromOglas(int oglasId)
        {
            var result = await this.prijave.DeleteFromOglas(oglasId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();
            var result = await this.prijave.Delete(id, userId);

            if (result.Failure)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet]
        public async Task<IEnumerable<PrijaveByUserModel>> MyPrijave()
        {
            var userId = this.currentUser.GetId();
            return await this.prijave.GetPrijaveByUser(userId);
        }

        [HttpGet]
        [Route("myprijave/{oglasId}")]
        public async Task<bool> PostojiPrijava(int oglasId)
        {
            var userId = this.currentUser.GetId();
            return await this.prijave.PrijavaNaOglas(oglasId, userId);
        }




    }
}
