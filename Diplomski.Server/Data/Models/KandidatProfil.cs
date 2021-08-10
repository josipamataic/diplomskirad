using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Data.Models
{
    public class KandidatProfil
    {
        //za kandidate:
        //   [Required]
        public string Ime { get; set; }
        // [Required]
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }     
        public string Obrazovanje { get; set; }

    }
}
