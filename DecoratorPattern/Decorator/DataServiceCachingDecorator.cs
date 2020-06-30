using System;
using System.Collections.Generic;
using DecoratorPattern.Services;
using Microsoft.Extensions.Caching.Memory;

namespace DecoratorPattern.Decorator
{
    public class DataServiceCachingDecorator : IDataService
    {
        private readonly IDataService _dataService;
        private readonly IMemoryCache _memoryCache;

        public DataServiceCachingDecorator(IDataService dataService, IMemoryCache memoryCache)
        {
            _dataService = dataService;
            _memoryCache = memoryCache;
        }

        public List<int> GetData()
        {
            const string cacheKey = "data-key";

            if (_memoryCache.TryGetValue<List<int>>(cacheKey, out var data))
            {
                return data;
            }

            data = _dataService.GetData();
            
            _memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(120));

            return data;
        }
    }
}