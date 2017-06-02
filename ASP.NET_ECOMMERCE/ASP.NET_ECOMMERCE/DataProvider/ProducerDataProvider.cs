using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.Models;
using ASP.NET_ECOMMERCE.Services;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public class ProducerDataProvider : IProducerDataProvider
    {
        private readonly Func<IDataService<Producer>> _dataServiceCreator;

        public ProducerDataProvider(Func<IDataService<Producer>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public void DeleteProducer(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<Producer> GetAllProducers()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }

        public Producer GetProducerById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveProducer(Producer producer)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Save(producer);
            }
        }
    }
}