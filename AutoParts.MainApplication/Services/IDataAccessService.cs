using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.MainApplication.Services
{
    interface IDataAccessService
    {
        void DeletePartEntry(Parts part);
        void SavePart(Parts part);
        Parts GetPartByID(int id);
        List<Parts> GetAllParts();
    }
}
