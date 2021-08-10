using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diplomski.Server.Data.Models.Base;

namespace Diplomski.Server.Data.Models
{
    public class Prijava : Entity
    {
        public int Id { get; set; }
        //public DateTime VrijemePrijave { get; set; }
        [Required]
        public string IdKandidat { get; set; }
        public User Kandidat { get; set; }
        public int IdOglas { get; set; }
        public Oglas Oglas { get; set; }

        public IEnumerable<Odgovor> Odgovori { get; set; } = new HashSet<Odgovor>();
    }
}
