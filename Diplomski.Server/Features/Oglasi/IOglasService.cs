using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Oglasi.Models;
using Diplomski.Server.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi
{
    public interface IOglasService
    {
        Task<int> Create(string naziv, int industrijaid, string opis, string userId);

        Task<IEnumerable<OglasListingServiceModel>> OglasByUser(string userId);
        Task<IEnumerable<ObavijestDetailsModel>> GetObavijesti(string userId);
        Task<int> GetBrojNovihObavijesti(string userId);

        Task<IEnumerable<ListAllOglasModel>> GetOglasi();
        Task<IEnumerable<ListAllOglasModel>> GetOglasiByPoslodavac(string userId);

        Task<OglasDetailsServiceModel> Details(int id);

        Task<Result> Update(int id, string naziv, int industrijaid, string opis, string userId);

        //"hard delete"
        Task<Result> Delete(int id, string userId);
        Task<Result> Arhiviraj(int oglasId, string userId);

        Task<Result> CreatePitanja(int oglasId, List<string> pitanja);
        Task<int> CreateObavijest(string userId, int oglasId, string naslov, string tekst);
        Task<Result> CreateKandidatObavijest(int obavijestId, List<string> userId);

        Task<Result> DeletePitanja(List<int> pitanja);

        Task<List<PitanjaDetailsModel>> GetPitanjaByOglasId(int oglasId);
        Task<List<KandidatDetailsModel>> GetKandidatiByOglasId(int oglasId, string userId);
        Task<List<KandidatDetailsModel>> GetKandidatiByPoslodavacId(string poslodavacId, int oglasId);

        Task<PoslodavacDetailsModel> GetPoslodavac(string poslodavacId);
    }
}
