using System.Collections.Generic;
using System.Diagnostics;
using DecoratorPattern.Services;
using Microsoft.Extensions.Logging;

namespace DecoratorPattern.Decorator
{
    public class DataServiceLoggingDecorator : IDataService
    {
        private readonly IDataService _dataService;
        private readonly ILogger<DataServiceLoggingDecorator> _logger;

        public DataServiceLoggingDecorator(IDataService dataService, ILogger<DataServiceLoggingDecorator> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public List<int> GetData()
        {
            _logger.LogInformation("Starting to get data");
            var stopwatch = Stopwatch.StartNew();

            var data = _dataService.GetData();

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished getting data in {elapsedTime} milliseconds");

            return data;
        }
    }
}