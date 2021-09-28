using BicycleOrderingService.Interfaces;
using System;
using System.Collections.Generic;

namespace BicycleOrderingService.Data
{
    class DataManager : IDataManager
    {
        public void Create<T>(string table, T record)
        {
            
        }

        public void Delete<T>(string table, Guid id)
        {
            
        }

        public void Edit<T>(string table, Guid id, T record)
        {
            
        }

        public T Find<T>(string table, Guid id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(string table)
        {
            throw new NotImplementedException();
        }
    }
}
