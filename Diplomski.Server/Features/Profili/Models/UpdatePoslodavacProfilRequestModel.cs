using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili.Models
{
    public class UpdatePoslodavacProfilRequestModel
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string NazivFirme { get; set; }
        public string Kontakt { get; set; }
        public string Opis { get; set; }
        public string Zemlja { get; set; }
        public bool PrivatniProfil { get; set; }
        public int IndustrijaId { get; set; }
        public string Industrija { get; set; }
    }
}
