using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Oglasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Prijave.Models
{
    public class PrijaveByUserModel
    {
        public int Id { get; set; }    
        public int OglasId { get; set; }
        public string NazivOglas { get; set; }
        public string Industrija { get; set; }
        public string Opis { get; set; }
        public string Firma { get; set; }
        public DateTime DatumPrijave { get; set; }
        public List<PitanjeOdgovorPrijavaModel> PitanjeOdgovor { get; set; }

    }

    public class PitanjeOdgovorPrijavaModel
    {
        public string TekstPitanje { get; set; }
        public string TekstOdgovor { get; set; }
    }
}
