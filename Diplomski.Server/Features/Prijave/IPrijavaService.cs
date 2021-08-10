using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Prijave.Models;
using Diplomski.Server.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Prijave
{
    public interface IPrijavaService
    {
        Task<int> Create(int oglasid, string userId);

        Task<bool> CreateOdgovori(string userId, int oglasId, int prijavaId, IEnumerable<PitanjeOdgovorModel> model);

        Task<IEnumerable<PrijaveByUserModel>> GetPrijaveByUser(string userId);

        //delete when oglas deleted
        Task<Result> DeleteFromOglas(int oglasId);

        Task<Result> Delete(int id, string userId);

        //obrisi odgovore 
        Task<Result> DeleteOdgovoriFromPrijava(int prijavaId);
        
        //provjeri jesam li već prijavljen
        Task<bool> PrijavaNaOglas(int oglasId, string userId);
    }
}
