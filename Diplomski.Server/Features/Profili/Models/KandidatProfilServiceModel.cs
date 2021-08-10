using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili.Models
{
    public class KandidatProfilServiceModel
    {
        public string Ime { get; set; }
        // [Required]
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }
        public string Email { get; set; }
        public string BrojMobitela { get; set; }
        public string Industrija { get; set; }
        public int? IndustrijaId { get; set; }
        public string Obrazovanje { get; set; }
        public string Zemlja { get; set; }
        public bool PrivatniProfil { get; set; }
    }
}
