using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Identity.Models
{
    public class KandidatProfileResponseModel
    {
        public string Ime { get; set; }
        // [Required]
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Industrija { get; set; }
        public string Obrazovanje { get; set; }
    }
}
