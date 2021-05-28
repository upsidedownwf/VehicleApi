using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApiData.DomainModels;

namespace VehicleApiData.Interfaces
{
    public interface IMakes
    {
        IEnumerable<Make> GetAllMakes();
        IEnumerable<Make> GetAllMakes1();
        Make GetAllMakebyId(int ID);
        void SaveChanges();
        void AddMake(Make make);
        void RemoveMake(Make make);

    }
}
