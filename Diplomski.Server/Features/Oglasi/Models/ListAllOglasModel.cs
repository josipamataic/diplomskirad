
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class ListAllOglasModel
    {
        public int Id { get; set; }
        public string PoslodavacId { get; set; }
        public string Naziv { get; set; }
        public int? IndustrijaId { get; set; }
        public string Industrija { get; set; }
        public string Opis { get; set; }
        public string Firma { get; set; }
        public string Lokacija { get; set; }
        public DateTime Datum { get; set; }

    }
}
