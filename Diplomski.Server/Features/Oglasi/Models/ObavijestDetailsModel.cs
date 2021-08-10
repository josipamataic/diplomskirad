using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class ObavijestDetailsModel
    {
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public int OglasId { get; set; }
        public string NazivOglas { get; set; }
        public string PoslodavacId { get; set; }
        public string NazivPoslodavca { get; set; }
        public DateTime Created { get; set; }
    }
}
