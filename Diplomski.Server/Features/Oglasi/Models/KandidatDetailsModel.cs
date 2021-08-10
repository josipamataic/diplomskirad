using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class KandidatDetailsModel
    {
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }
        public string Industrija { get; set; }
        public string Obrazovanje { get; set; }
        public string Zemlja { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }
        public DateTime DatumPrijave { get; set; }
        public List<KandidatOdgovor> Odgovori { get; set; }
    }

    public class KandidatOdgovor
    {
        public int PitanjeId { get; set; }
        public string TekstPitanje { get; set; }
        public int OdgovorId { get; set; }
        public string TekstOdgovor { get; set; }
    }
}
