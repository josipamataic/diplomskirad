using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diplomski.Server.Data.Models.Base;

namespace Diplomski.Server.Data.Models
{
    public class Odgovor : Entity
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int IdPItanja { get; set; }
        public Pitanje Pitanje { get; set; }
        public User Kandidat { get; set; }
        [Required]
        public string IdKandidata { get; set; }
        public int IdOglasa { get; set; }
        public Oglas Oglas { get; set; }
        public int IdPrijava { get; set; }
        public Prijava Prijava { get; set; }

    }
}
