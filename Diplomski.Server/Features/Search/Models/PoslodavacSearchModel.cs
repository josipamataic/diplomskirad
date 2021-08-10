using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Search.Models
{
    public class PoslodavacSearchModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string NazivFirme { get; set; }
        public string Kontakt { get; set; }
        public string Opis { get; set; }
    }
}
