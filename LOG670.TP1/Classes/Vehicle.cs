using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LOG670.TP1.Classes
{
    public class Vehicle : Object
    {
        public Vehicle(int position, int speed, Vehicle followedBy, Vehicle following, float fuelLevel,
            Navigator theNavigator, Brand carBrand) : base(position)
        {
            Speed = speed;
            FollowedBy = followedBy;
            Following = following;
            FuelLevel = fuelLevel;
            TheNavigator = theNavigator;
            CarBrand = carBrand;
        }

        public int Speed { get; private set; }
        public Vehicle FollowedBy { get; private set; }
        public Vehicle Following { get; set; }
        public Vehicle FrontCar { get; set; }
        public float FuelLevel { get; private set; }
        public Navigator TheNavigator { get; private set; }
        public Brand CarBrand { get; private set; }


        public void StartConvoy(Vehicle vehicle)
        {
            //pre VehicleStartingNotFollowing: self.following.isUndefined 
            //pre VehicleStartingNotFollowed: self.frontcar.isUndefined 
            //pre VehicleStartingNoNavigator: self.navigator.isAlive = false
            //pre VehicleEntryNotFollowing: vehicle.following.isUndefined 
            //pre VehicleEntryNoNavigator: vehicle.navigator.isAlive = false 
            Contract.Requires(Following == null && FrontCar == null && !TheNavigator.IsActive && vehicle.Following == null && !vehicle.TheNavigator.IsActive);

            //post VehicleStartedNotFollowing: self.frontcar.isUndefined
            //post VehicleStartedFollowed: self.following = vehicle
            //post VehicleStartedNoNavigator: self.navigator.isAlive = false
            //post VehicleEnteredFollowing: vehicle.frontcar = self
            //post VehicleEnteredNavigatorOn: vehicle.navigator.isAlive=true

            Contract.Ensures(FrontCar == null && Following == vehicle && !TheNavigator.IsActive && vehicle.FrontCar == this && vehicle.TheNavigator.IsActive);
        }

        public void JoinConvoy(Vehicle vehicle)
        {
            //pre FrontCarFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //pre FrontCarFollowedByNobody: vehicle.following.isUndefined
            //pre FrontCarNaviOn: vehicle.navigator.isAlive=true
            //pre VehicleEntryFollowingNoOne: self.frontcar.isUndefined
            //pre VehicleEntryNoNavigator: self.navigator.isAlive = false
            Contract.Requires(vehicle.FrontCar != null && vehicle.Following == null && vehicle.TheNavigator.IsActive && FrontCar == null && !TheNavigator.IsActive);

            //post FrontCarStillFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //post FrontCarNowFollowedBySelf: vehicle.following = self
            //post FrontCarNaviStillOn: vehicle.navigator.isAlive=true
            //post VehicleEntryNowFollowingSomeone: self.frontcar = vehicle
            //post VehicleEntryNowNavigatorOn: self.navigator.isAlive = true
            Contract.Ensures(vehicle.FrontCar != null && vehicle.Following == this && vehicle.TheNavigator.IsActive &&
                             FrontCar == vehicle && TheNavigator.IsActive);

        }

        public void LeaveConvoy(Vehicle vehicle)
        {
            //pre VehicleIsFollowing: self.frontcar.isUndefined = false TODO: inconsistant 
            //pre VehicleHeadFollowed: self.frontcar.following = self
            //pre VehicleStartedNoNavigator: self.navigator.isAlive = true
            Contract.Requires(FrontCar != null && FrontCar.Following == this && TheNavigator.IsActive);

            //post VehicleHeadNotLongerFollowed: not Vehicle.allInstances->exists(v | v.following = self)
            //post VehicleLeavingNoNavigator: self.navigator.isAlive = false
            //post VehicleLeavingNotFollowing: self.frontcar.isUndefined
            Contract.Ensures((FrontCar == null || !IsVehicleInConvoy(vehicle.FrontCar, vehicle)) && !TheNavigator.IsActive );
        }

        /// <summary>
        /// Méthode récursive qui verifie si le véhicule est dans le convoie
        /// </summary>
        /// <param name="vehicleChain">Le véhicule a comparer</param>
        /// <param name="vehicle">Le vehicule qui a quité le convoie</param>
        /// <returns></returns>
        private bool IsVehicleInConvoy(Vehicle vehicleChain, Vehicle vehicle)
        {
            if (vehicleChain.FollowedBy == null)
                return false;
            
            if (vehicleChain.FollowedBy == vehicle)
                return true;

            return IsVehicleInConvoy(vehicleChain.FollowedBy, vehicle);
        }

        

        public void SetDestination(Destination destination)
        {
            //pre DestinationNotCurrentDestination: not (self.navigator.destination = dest)
            //pre NavigatorOn: self.navigator.isAlive = true
            Destination previousDestination = TheNavigator.TheDestination;
            Contract.Requires(TheNavigator.TheDestination != destination && TheNavigator.IsActive);



            //post DestinationNowCurrentDestination: self.navigator.destination = dest
            //post DestinationNowOldDestination: not (self.navigator.destination = self.navigator.destination@pre)
            //post NavigatorStillOn: self.navigator.isAlive = true
            Contract.Ensures(TheNavigator.TheDestination == destination && TheNavigator.TheDestination != previousDestination);
        }


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Following == null ||
                               (this.Following.FollowedBy == this &&
                                this.TheNavigator.IsActive));

            Contract.Invariant(this.FollowedBy == null ||
                               (this.FollowedBy.Following == this &&
                                (this.Following == null ||
                                 !this.TheNavigator.IsActive)));
        }

        public Vehicle(int position) : base(position)
        {
        }
    }
}