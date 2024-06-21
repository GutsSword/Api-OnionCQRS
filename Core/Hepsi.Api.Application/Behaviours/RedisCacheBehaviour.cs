using Hepsi.Api.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Behaviours
{
    public class RedisCacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehaviour(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cacheData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cacheData is not null)
                    return cacheData;

                var response = await next();
                if(response is not null)
                    await redisCacheService.SetAsync(cacheKey, response,DateTime.Now.AddMinutes(cacheTime));

                return response;
            }

            return await next();
        }
    }
}
