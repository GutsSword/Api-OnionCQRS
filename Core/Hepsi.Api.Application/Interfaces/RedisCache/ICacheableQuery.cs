using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Interfaces.RedisCache
{
    public interface ICacheableQuery
    {
        public string CacheKey { get; }
        public double CacheTime { get; }
    }
}
