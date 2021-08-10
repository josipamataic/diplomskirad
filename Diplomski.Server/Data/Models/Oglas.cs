using Diplomski.Server.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Data.Models
{
    public class Oglas : Entity
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
       
        public int? IndustrijaId { get; set; }
        public Industrija Industrija { get; set; }
       // public DateTime Datum { get; set; }        
        [Required]
        public string Opis { get; set; }
        [Required]
        public string PoslodavacId { get; set; }
        public User Poslodavac { get; set; }
        public bool Arhiviran { get; set; }

        public IEnumerable<Prijava> Prijave { get; set; } = new HashSet<Prijava>();
        public IEnumerable<Pitanje> Pitanja { get; set; } = new HashSet<Pitanje>();
        public IEnumerable<Odgovor> Odgovori { get; set; } = new HashSet<Odgovor>();
        public IEnumerable<Obavijest> Obavijesti { get; set; } = new HashSet<Obavijest>();
    }
}
