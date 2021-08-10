using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Data.Models
{
    public class Industrija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public IEnumerable<Oglas> Oglasi { get; set; } = new HashSet<Oglas>();
        public IEnumerable<User> Korisnici { get; set; } = new HashSet<User>();
    }
}
