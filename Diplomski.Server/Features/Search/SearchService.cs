using Diplomski.Server.Data;
using Diplomski.Server.Features.Search.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Search
{
    public class SearchService : ISearchService
    {
        private readonly DiplomskiDbContext data;

        public SearchService(DiplomskiDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<PoslodavacSearchModel>> Poslodavci(string query)
        {
            var naziviPoslodavaca = await this.data.Users.Where(u => u.PoslodavacProfil.NazivFirme.ToLower().Contains(query.ToLower())
                                            || u.UserName.ToLower().Contains(query.ToLower()))
                                    .Select(u=> new PoslodavacSearchModel
                                    {
                                        UserId = u.Id,
                                        UserName = u.UserName,
                                        NazivFirme = u.PoslodavacProfil.NazivFirme,
                                        Kontakt = u.PoslodavacProfil.Kontakt,
                                        Opis = u.PoslodavacProfil.Opis
                                    })
                                    .ToListAsync();

            return naziviPoslodavaca;

        }
    }
}
