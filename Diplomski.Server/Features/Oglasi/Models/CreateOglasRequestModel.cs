using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class CreateOglasRequestModel
    {
        public string Naziv { get; set; }
        [Required]
        public int IndustrijaId { get; set; }
       // public DateTime Datum { get; set; }
        [Required]
        public string Opis { get; set; }

        public List<string> Pitanja { get; set; }
    }
}
