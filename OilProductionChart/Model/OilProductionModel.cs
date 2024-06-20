using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilProductionChart
{
    public class OilProductionModel
    {
        public string Country { get; set; }
        public double Production { get; set; }
        public string FlagImage { get; set; }

        public OilProductionModel(string country, double production, string flagImage)
        {
            Country = country;
            Production = production;
            FlagImage = flagImage;
        }
    }
}
