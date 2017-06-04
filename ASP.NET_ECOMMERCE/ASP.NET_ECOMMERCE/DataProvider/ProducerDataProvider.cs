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
        private readonly IDataService<Producer> _dataServiceCreator;

        public ProducerDataProvider(IDataService<Producer> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public void DeleteProducer(int id)
        {

            _dataServiceCreator.Delete(id);

        }

        public ICollection<Producer> GetAllProducers()
        {


            return _dataServiceCreator.GetAll();

        }

        public Producer GetProducerById(int? id)
        {

            return _dataServiceCreator.GetById(id.Value);

        }

        public void SaveProducer(Producer producer)
        {

            _dataServiceCreator.Save(producer);

        }
    }
}