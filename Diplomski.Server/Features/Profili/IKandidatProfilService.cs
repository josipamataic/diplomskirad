using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public interface IKandidatProfilService
    {
        Task<KandidatProfilServiceModel> MyProfil(string userId);
        Task<IEnumerable<KandidatProfilServiceModel>> GetKandidati();
        Task<Result> Update(string userId, string userName, string ime, string prezime, string email, string phoneNumber, DateTime datumRodenja, int industrijaid, string obrazovanje, string zemlja, bool privatniProfil);

        Task<List<IndustrijaListingModel>> GetIndustrije();

        Task<Result> Delete(string userId);
        Task<Result> DeleteUser(string userId);

    }
}
