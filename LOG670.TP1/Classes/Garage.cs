using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LOG670.TP1.Classes
{
    public class Garage : Destination {
        public Garage(int pos, List<Brand> canRepair) : base(pos, false)
        {
            CanRepair = canRepair;
        }

        public List<Brand> CanRepair { get; private set; }
       
        public bool CheckRepairBrand(Vehicle v)
        {
            return CanRepair.Contains(v.CarBrand);
        }

        public void RepairVehicle(Vehicle v)
        {
            Contract.Requires(CheckRepairBrand(v));
            Contract.Requires(!v.TheNavigator.Engine.IsOk);
            Contract.Requires(v.Position == this.Position);
            Contract.Ensures(!v.TheNavigator.Engine.IsOk);
            Contract.Ensures(CheckRepairBrand(v));
            Contract.Ensures(v.Position == this.Position);
            Contract.EndContractBlock();

            v.TheNavigator.Engine.IsOk = true;
        }
    }
}