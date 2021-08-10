using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diplomski.Server.Data.Models.Base;

namespace Diplomski.Server.Data.Models
{
    public class Pitanje : Entity
    {
        public int Id { get; set; }
        [Required]
        public string Tekst { get; set; }
        public int OglasId { get; set; }
        public Oglas Oglas { get; set; }

        public IEnumerable<Odgovor> Odgovori { get; set; } = new HashSet<Odgovor>();
    }
}
