using Fujitsu.Data;
using Fujitsu.Models;
using System.Runtime.CompilerServices;

namespace Fujitsu.Lov
{
    public class CustomerLov
    {
        private readonly TestFidContext db;

        public CustomerLov()
        {
            this.db = new TestFidContext();
        }



        public List<DropdownModel> DropdownProv(List<DropdownModel> model)
        {
            var prov = ddProv();

            foreach (var item in prov)
            {
                DropdownModel newItem = new DropdownModel
                {
                    Province = item.Province,
                };
                model.Add(newItem);
            };
            return model;


        }
        public List<DropdownModel> DropdownCity(string prov)
        {
            List<DropdownModel> model = new List<DropdownModel>();
            var City = ddCity(prov);

            foreach (var item in City)
            {
                DropdownModel newItem = new DropdownModel
                {
                    City = item.City,
                };
                model.Add(newItem);
            };
            return model;
        }


        private List<TbMcity> ddProv()
        {
            var prov = db.TbMcities.Select(x => x.Province).Distinct().ToList();

            var ProvObjDist = prov.Select(p => new TbMcity { Province = p }).ToList();

            return ProvObjDist;
        }
        private List<TbMcity> ddCity(string prov)
        {
            var city = db.TbMcities.Where(x => x.Province == prov).Select(x => x.City).Distinct().ToList();

            var CityObjDist = city.Select(p => new TbMcity { City = p }).ToList();

            return CityObjDist;
        }
    }
}
