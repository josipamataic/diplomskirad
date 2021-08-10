using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models
{
    public class OglasDetailsServiceModel : OglasListingServiceModel
    {      

        public string Industrija { get; set; }
        public int? IndustrijaId { get; set; }
        public string Opis { get; set; }
        public string PoslodavacId { get; set; }
        public string UserName { get; set; }
        public string Firma { get; set; }
        public bool Arhiviran { get; set; }
      //  public DateTime Datum { get; set; }
        public List<PitanjaDetailsModel> Pitanja { get; set; }
    }

    public class PitanjaDetailsModel
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
    }
}
