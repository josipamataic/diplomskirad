using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public interface IPoslodavacProfilService
    {
        Task<PoslodavacProfilServiceModel> MyProfil(string userId);
        Task<IEnumerable<ListPoslodavacProfil>> GetPoslodavci();
        Task<Result> Update(string userId, string userName, string email, int industrijaId, string nazivFirme, string kontakt, string opis, string zemlja, bool privatniProfil);
    }
}
