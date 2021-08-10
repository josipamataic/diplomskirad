using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diplomski.Server.Data.Models.Base;

namespace Diplomski.Server.Data.Models
{
    public class KandidatObavijest : Entity
    {
        public int Id { get; set; }
        public Obavijest Obavijest { get; set; }
        public int ObavijestId { get; set; }
        [Required]
        public string KandidatId { get; set; }
        public User Kandidat { get; set; }
        public bool Otvoreno { get; set; }
    }
}
