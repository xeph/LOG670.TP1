using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LOG670.TP1.Classes
{
    public class Vehicle : Object
    {
        public Vehicle(int position, int speed, Destination destination, Brand carBrand) : base(position)
        {
            Speed = speed;
            FollowedBy = null;
            Following = null;
            FuelLevel = 1.0f;
            TheNavigator = new Navigator(destination);
            CarBrand = carBrand;
        }

        public int Speed { get; private set; }
        public Vehicle FollowedBy { get; private set; }
        public Vehicle Following { get; set; }
        public Vehicle FrontCar { get; set; }
        public float FuelLevel { get; private set; }
        public Navigator TheNavigator { get; private set; }
        public Brand CarBrand { get; private set; }

        /// <summary>
        /// Begins a convoy with vehicle received. Received vehicle is the leader.
        /// </summary>
        /// <param name="vehicle"></param>
        public void StartConvoy(Vehicle vehicle)
        {
            //pre VehicleStartingNotFollowing: self.following.isUndefined 
            //pre VehicleStartingNotFollowed: self.frontcar.isUndefined 
            //pre VehicleStartingNoNavigator: self.navigator.isAlive = false
            //pre VehicleEntryNotFollowing: vehicle.following.isUndefined 
            //pre VehicleEntryNoNavigator: vehicle.navigator.isAlive = false 
            Contract.Requires(Following == null && FrontCar == null && !TheNavigator.IsActive && vehicle.Following == null && !vehicle.TheNavigator.IsActive);

            this.Following = vehicle;
            this.FrontCar = vehicle;
            vehicle.TheNavigator.IsActive = true;
            
            //post VehicleStartedNotFollowing: self.frontcar.isUndefined 
            //post VehicleStartedFollowed: self.following = vehicle
            //post VehicleStartedNoNavigator: self.navigator.isAlive = false
            //post VehicleEnteredFollowing: vehicle.frontcar = self
            //post VehicleEnteredNavigatorOn: vehicle.navigator.isAlive=true

            Contract.Ensures(FrontCar == null && Following == vehicle && !TheNavigator.IsActive && vehicle.FrontCar == vehicle && vehicle.TheNavigator.IsActive);
        }

        /// <summary>
        /// Te join au convoy du véhicule recu
        /// </summary>
        /// <param name="vehicle">le véhicule qui fait partie du convoi que tu veut te joindre à</param>
        public void JoinConvoy(Vehicle vehicle)
        {
            //pre FrontCarFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //pre FrontCarFollowedByNobody: vehicle.followedBy.isUndefined
            //pre FrontCarNaviOn: vehicle.frontcar.navigator.isAlive
            //pre VehicleEntryFollowingNoOne: self.frontcar.isUndefined
            //pre VehicleEntryNoNavigator: not(self.navigator.isAlive)
            Contract.Requires(vehicle.FrontCar != null && vehicle.Following == null && vehicle.TheNavigator.IsActive && FrontCar == null && !TheNavigator.IsActive);

            vehicle.FollowedBy = this;
            Following = vehicle;
            FrontCar = vehicle.FrontCar;
            TheNavigator.IsActive = true;


            //post FrontCarStillFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //post VehicleNowFollowedBySelf: vehicle.followedBy = self
            //post FrontCarNaviStillOn: vehicle.frontcar.navigator.isAlive
            //post VehicleEntryNowFollowingSomeone: not(self.following.isUndefined)
            //post VehicleEntryNowNavigatorOn: self.navigator.isAlive
            Contract.Ensures(vehicle.FrontCar != null && vehicle.FollowedBy == this && vehicle.FrontCar.TheNavigator.IsActive && Following != null
                              && TheNavigator.IsActive);

        }

        /// <summary>
        /// tells to vehicle to leave the convoy of which he is a part of. 
        /// 3 possible senarios: 
        /// We are the leader. In which case, appoint following car as leader, and leave convoy
        /// We are between leader and last car. Assign the car you are following the car you're followed by and the car you're followedBy the car you're following
        /// We are last car, remove yourself as the followedBy of the car you are following
        /// 
        /// All three senarios finish you remove your followedBy and Following, turn off your navi and clear your front car.
        /// </summary>
        public void LeaveConvoy()
        {
            //pre VehicleIsFollowing: not(self.frontcar.isUndefined)
            //pre VehicleHeadFollowed: not(self.frontcar.followedBy.isUndefined)
            //pre VehicleStartedNoNavigator: self.navigator.isAlive
            Contract.Requires(FrontCar != null && FrontCar.FollowedBy != null && TheNavigator.IsActive);
            Vehicle frontCarReference = FrontCar;

            //If this is the front car, set car following you to front car, and update all following vehicles.
            if (FrontCar == this)
            {
                SetFollowingCarsToFrontCar(this.FollowedBy, this.FollowedBy);
            } 
            else if (FollowedBy != null) //is between first and last car
            {
                Following.FollowedBy = FollowedBy.Following;
                FollowedBy.Following = Following.FollowedBy;
            }
            else //is last car
            {
                Following.FollowedBy = null;
            }

            FollowedBy = null;
            Following = null;
            FrontCar = null;
            TheNavigator.IsActive = false;

            //post SelfNoLongerFollowedBy: not Vehicle.allInstances->exists(v | v.following = self)
            //post VehicleLeavingNoNavigator: not(self.navigator.isAlive)
            //post VehicleLeavingNotFollowing: self.frontcar.isUndefined
            Contract.Ensures((FrontCar == null || !IsVehicleInConvoy(frontCarReference, this)) && !TheNavigator.IsActive);
        }

        private void SetFollowingCarsToFrontCar(Vehicle newFrontCar, Vehicle followingVehicle)
        {
            followingVehicle.FrontCar = newFrontCar;
            if (followingVehicle.FollowedBy != null)
            {
                SetFollowingCarsToFrontCar(newFrontCar, followingVehicle.FollowedBy);
            }
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
            //pre NavigatorOn: self.navigator.isAlive
            Contract.Requires(TheNavigator.TheDestination != destination && TheNavigator.IsActive);
            Destination previousDestination = TheNavigator.TheDestination;


            //post DestinationNowCurrentDestination: self.navigator.destination = dest
            //post DestinationNowOldDestination: not (self.navigator.destination = self.navigator.destination@pre)
            //post NavigatorStillOn: self.navigator.isAlive
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