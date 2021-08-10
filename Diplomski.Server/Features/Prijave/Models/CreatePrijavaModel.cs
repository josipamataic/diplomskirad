using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Prijave.Models
{
    public class CreatePrijavaModel
    {
        public int OglasId { get; set; }
       // public List<string> Odgovori { get; set; }        
       public List<PitanjeOdgovorModel> Odgovori { get; set; }
       
    }

    public class PitanjeOdgovorModel
    {
        public int PitanjeId { get; set; }
        public string OdgovorTekst { get; set; }
    }
}
