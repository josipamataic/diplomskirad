using Diplomski.Server.Features.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<PoslodavacSearchModel>> Poslodavci(string query);
    }
}
