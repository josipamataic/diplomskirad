using Diplomski.Server.Features.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Search
{
    public class SearchController : ApiController
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search)
        {
            this.search = search;
        }

        /* [HttpGet]
         [Route(nameof(KandidatProfiles))]
         public async Task<ActionResult> KandidatProfiles(string query)
         {
             return null;
         }*/

        [HttpGet]
        [Route(nameof(PoslodavacProfiles))]
        public async Task<IEnumerable<PoslodavacSearchModel>> PoslodavacProfiles(string query)
        {
            var profili = await this.search.Poslodavci(query);
            return profili;
        }
    }
}
