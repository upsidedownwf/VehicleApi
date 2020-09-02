using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApiData.DomainModels;
using VehicleApiData.Interfaces;
using VehicleApiServices.HelperModels;

namespace VehicleApiServices.Services
{
    public class MakesServices : IMakes
    {
        private VehicleApiContext _context;

        public MakesServices(VehicleApiContext context)
        {
            _context = context;
        }

        public  IEnumerable<Make> GetAllMakes()
        {
          return  _context.Makes.Include(m=> m.Models);
        }

        public Make GetAllMakebyId(int ID)
        {
            return _context.Makes.Include(m => m.Models).Wheres(x => x.Id == ID && x.Name != null).FirstorDefaults();
        }

        private IEnumerable<Make> GetAllMakebyIdsss(int ID)
        {
            return _context.Makes.Include(m => m.Models).Wheres(x => x.Id == ID && x.Name != null).Select(
                x =>
                new Make { Id = x.Id }
            );
        }
        private Make Dic(int ID)
        {
            IDictionary<int, Make> dic = _context.Makes.Include(m => m.Models).Wheres(x => x.Id == ID && x.Name != null).ToDictionary(x => x.Id, x => x);
            return dic[ID];
        }
        public void SaveChanges()
        { 
            _context.SaveChanges();
        }

        public void AddMake(Make make)
        {
            _context.Add(make);
            SaveChanges();
        }
        public void RemoveMake(Make make)
        {
            _context.Remove(make);
            SaveChanges();
        }
    }
}
