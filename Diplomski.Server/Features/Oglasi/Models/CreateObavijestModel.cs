using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class CreateObavijestModel
    {
        public int IdOglas { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public List<string> KandidatIds { get; set; }
    }
}
