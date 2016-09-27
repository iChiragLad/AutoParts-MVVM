using AutoParts.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParts.Model;

namespace AutoParts.MainApplication.Services
{
    class DataAccessService : IDataAccessService
    {
        IAutoPartsRepository repository;
        public DataAccessService(IAutoPartsRepository rep)
        {
            repository = rep;
        }

        public void DeletePartEntry(Parts part)
        {
            repository.DeletePart(part);
        }

        public List<Parts> GetAllParts()
        {
            return repository.GetAllParts();
        }

        public Parts GetPartByID(int id)
        {
            return repository.GetPartByID(id);
        }

        public void SavePart(Parts part)
        {
            repository.UpdatePart(part);
        }
    }
}
