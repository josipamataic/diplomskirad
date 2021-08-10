using Diplomski.Server.Data.Models.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public KandidatProfil KandidatProfil { get; set; }

        public PoslodavacProfil PoslodavacProfil { get; set; }

        public int? IndustrijaId { get; set; }
        public Industrija Industrija { get; set; }

        public string Zemlja { get; set; }
        public bool PrivatniProfil { get; set; }
    
        
        //public string Role { get; set; }

        //create, update
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        

        public IEnumerable<Oglas> Oglasi { get; set; } = new HashSet<Oglas>();
        public IEnumerable<Odgovor> Odgovori { get; set; } = new HashSet<Odgovor>();
        public IEnumerable<Prijava> Prijave { get; set; } = new HashSet<Prijava>();
        public IEnumerable<Obavijest> Obavijesti { get; set; } = new HashSet<Obavijest>();
        public IEnumerable<KandidatObavijest> KandidatObavijesti { get; set; } = new HashSet<KandidatObavijest>();
        
    }
}
