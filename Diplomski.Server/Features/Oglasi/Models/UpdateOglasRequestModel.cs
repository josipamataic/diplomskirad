using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Diplomski.Server.Features.Oglasi.Models
{
    public class UpdateOglasRequestModel
    {
       
        public string Naziv { get; set; }
        public int IndustrijaId { get; set; }
     //   public DateTime UpdateTime { get; set; }
        public string Opis { get; set; }
        public List<int> ObrisanaPitanjaIds { get; set; }
        public List<string> NovaPitanja { get; set; }
    }
}
