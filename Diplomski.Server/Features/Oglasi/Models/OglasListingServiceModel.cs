using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi.Models    
{
    public class OglasListingServiceModel
    {
        public int Id { get; set; }
       
        public string Naziv { get; set; }       
       
        public DateTime Datum { get; set; }    
        
        public bool Arhiviran { get; set; }
       
      
    }
}
