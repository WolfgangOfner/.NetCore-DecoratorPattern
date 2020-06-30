using System.Collections.Generic;
using System.Threading;

namespace DecoratorPattern.Services
{
    public class DataService : IDataService
    {
        public List<int> GetData()
        {
            var data = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                data.Add(i);

                Thread.Sleep(350);
            }

            return data;
        }
    }
}