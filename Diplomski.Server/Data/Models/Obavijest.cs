using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diplomski.Server.Data.Models.Base;

namespace Diplomski.Server.Data.Models
{
    public class Obavijest : Entity
    {
        public int Id { get; set; }
        [Required]
        public string Naslov { get; set; }
        public string Tekst { get; set; }
      //  public DateTime Datum { get; set; }

        public int IdOglas { get; set; }
        public Oglas Oglas { get; set; }
        
        [Required]
        public string IdPoslodavac { get; set; }
        public User Poslodavac { get; set; }

        public IEnumerable<KandidatObavijest> KandidatObavijesti { get; set; } = new HashSet<KandidatObavijest>();
    }
}
