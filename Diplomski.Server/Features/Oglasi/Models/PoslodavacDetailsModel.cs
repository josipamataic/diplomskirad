using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class PoslodavacDetailsModel
    {
        public string Id { get; set; }
        public string NazivFirme { get; set; }
        public string Email { get; set; }
        public string Kontakt { get; set; }
        public string Opis { get; set; }
        public string Zemlja { get; set; }
        public string Industrija { get; set; }
        public int? IndustrijaId { get; set; }
    }
}
