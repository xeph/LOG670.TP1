using System.Collections.Generic;

namespace LOG670.TP1.Classes
{
    public class Garage {
        public Garage(List<Brand> canRepair)
        {
            CanRepair = canRepair;
        }

        public List<Brand> CanRepair { get; private set; }
       
    }
}