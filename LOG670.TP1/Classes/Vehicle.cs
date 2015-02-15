using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace LOG670.TP1.Classes
{
    public class Vehicle : Object
    {
        private static IList<Vehicle> AllVehicles = new List<Vehicle>();

        public Vehicle(int position, int speed, Destination destination, Brand carBrand) : base(position)
        {
            Speed = speed;
            Following = null;
            FrontCar = null;
            FuelLevel = 1.0f;
            TheNavigator = new Navigator(destination);
            CarBrand = carBrand;

            AllVehicles.Add(this);
        }

        public int Speed { get; private set; }
        public Vehicle Following { get; private set; }
        public Vehicle FrontCar { get; private set; }
        public float FuelLevel { get; private set; }
        public Navigator TheNavigator { get; private set; }
        public Brand CarBrand { get; private set; }

        /// <summary>
        /// Begins a convoy with vehicle received. Received vehicle is the follower.
        /// </summary>
        /// <param name="vehicle"></param>
        public void StartConvoy(Vehicle vehicle)
        {
            //pre VehicleStartingNotFollowing: self.following.isUndefined
            //pre VehicleStartingNotFollowed: self.frontcar.isUndefined
            //pre VehicleStartingNoNavigator: self.navigator.isAlive = false
            //pre VehicleEntryNotFollowing: vehicle.following.isUndefined
            //pre VehicleEntryNoNavigator: vehicle.navigator.isAlive = false
            Contract.Requires(Following == null);
            Contract.Requires(FrontCar == null);
            Contract.Requires(!TheNavigator.IsActive);
            Contract.Requires(vehicle.Following == null);
            Contract.Requires(!vehicle.TheNavigator.IsActive);
            //post VehicleStartedNotFollowing: self.frontcar.isUndefined
            //post VehicleStartedFollowed: self.following = vehicle
            //post VehicleStartedNoNavigator: self.navigator.isAlive = false
            //post VehicleEnteredFollowing: vehicle.frontcar = self
            //post VehicleEnteredNavigatorOn: vehicle.navigator.isAlive=true
            Contract.Ensures(FrontCar == null);
            Contract.Ensures(Following == vehicle);
            Contract.Ensures(!TheNavigator.IsActive);
            Contract.Ensures(vehicle.FrontCar == this);
            Contract.Ensures(vehicle.TheNavigator.IsActive);
            Contract.EndContractBlock();

            vehicle.TheNavigator.IsActive = true;
            Following = vehicle;
            vehicle.FrontCar = this;
        }

        /// <summary>
        /// Te join au convoy du véhicule recu
        /// </summary>
        /// <param name="vehicle">le véhicule qui fait partie du convoi que tu veut te joindre à</param>
        public void JoinConvoy(Vehicle vehicle)
        {
            Contract.Requires(vehicle != null);
            
            //pre FrontCarFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //pre FrontCarFollowedByNobody: vehicle.following.isUndefined
            //pre FrontCarNaviOn: vehicle.navigator.isAlive=true
            //pre VehicleEntryFollowingNoOne: self.frontcar.isUndefined
            //pre VehicleEntryNoNavigator: self.navigator.isAlive = false
            Contract.Requires(vehicle.FrontCar != null);
            Contract.Requires(vehicle.Following == null);
            Contract.Requires(vehicle.TheNavigator.IsActive);
            Contract.Requires(FrontCar == null);
            Contract.Requires(!TheNavigator.IsActive);
            //post FrontCarStillFollowingSomeone: not (vehicle.frontcar.isUndefined)
            //post FrontCarNowFollowedBySelf: vehicle.following = self
            //post FrontCarNaviStillOn: vehicle.navigator.isAlive=true
            //post VehicleEntryNowFollowingSomeone: self.frontcar = vehicle
            //post VehicleEntryNowNavigatorOn: self.navigator.isAlive = true
            Contract.Ensures(vehicle.FrontCar != null);
            Contract.Ensures(vehicle.Following == this);
            Contract.Ensures(vehicle.TheNavigator.IsActive);
            Contract.Ensures(FrontCar == vehicle);
            Contract.Ensures(TheNavigator.IsActive);
            Contract.EndContractBlock();


            TheNavigator.IsActive = true;
            vehicle.Following = this;
            FrontCar = vehicle;
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
            //pre VehicleIsFollowing: self.frontcar.isUndefined = false
            //pre VehicleHeadFollowed: self.frontcar.following = self
            //pre VehicleStartedNoNavigator: self.navigator.isAlive = true
            Contract.Requires(FrontCar != null);
            Contract.Requires(FrontCar.Following != null);
            Contract.Requires(TheNavigator.IsActive);
            //post VehicleHeadNotLongerFollowed: not Vehicle.allInstances->exists(v | v.following = self)
            //post VehicleLeavingNoNavigator: self.navigator.isAlive = false
            //post VehicleLeavingNotFollowing: self.frontcar.isUndefined
            Contract.Ensures(AllVehicles.All(x => x.FrontCar != this && x.Following != this));
            Contract.Ensures(!TheNavigator.IsActive);
            Contract.Ensures(FrontCar == null);
            Contract.EndContractBlock();

            if (FrontCar != null)
                FrontCar.Following = Following;
            else if (Following != null)
                Following.TheNavigator.IsActive = false;

            if (Following != null)
                Following.FrontCar = FrontCar;

            Following = null;
            FrontCar = null;
            TheNavigator.IsActive = false;
        }

        /// <summary>
        /// Méthode récursive qui verifie si le véhicule est dans le convoie TODO: aurais besoin access au convoie pour verifier
        /// </summary>
        /// <param name="vehicleChain">Le véhicule a comparer</param>
        /// <param name="vehicle">Le vehicule qui a quité le convoie</param>
        /// <returns></returns>
        private bool IsVehicleInConvoy(Vehicle vehicleChain, Vehicle vehicle)
        {
            if (vehicleChain.Following == null)
                return false;
            
            if (vehicleChain.Following == vehicle)
                return true;

            return IsVehicleInConvoy(vehicleChain.Following, vehicle);
        }

        
        public void SetDestination(Destination destination)
        {
            //pre DestinationNotCurrentDestination: not (self.navigator.destination = dest)
            //pre NavigatorOn: self.navigator.isActive
            Contract.Requires(TheNavigator.TheDestination != destination);
            Contract.Requires(TheNavigator.IsActive);
            //post DestinationNowCurrentDestination: self.navigator.destination = dest
            //post DestinationNowOldDestination: not (self.navigator.destination = self.navigator.destination@pre) //TODO: implicitly deduced if first post-condition passes
            //post NavigatorStillOn: self.navigator.isActive
            Contract.Ensures(TheNavigator.TheDestination == destination);
            Contract.Ensures(TheNavigator.IsActive);
            Contract.EndContractBlock();

            TheNavigator.SetDestination(destination);
        }

        public void ChangeLane(Lane l)
        {
            //pre LaneNotCurrentLane: not (self.lane = lane)
            Contract.Requires(!l.Objects.Contains(this));
            //post LaneNowCurrentLane: self.lane = lane
            //post LaneNotOldLane: not (self.lane = self.lane@pre)
            Contract.Ensures(l.Objects.Contains(this));
            Contract.Ensures(!Highway.AllHighway.SelectMany(x => x.Lanes).Where(x => x != l).Any(x => x.Objects.Contains(this)));
            Contract.EndContractBlock();

            Highway.AllHighway.SelectMany(x => x.Lanes).Single(x => x.Objects.Contains(this)).Objects.Remove(this);
            l.Objects.Add(this);
        }


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            // En aucun temps, le leader d'un convoi ne peut être sur le navigateur
            Contract.Invariant(this.FrontCar == null || this.TheNavigator.IsActive);

            Contract.Invariant(
                AllVehicles.Select(x => x.FrontCar).Where(x => x != null).Count() == 
                (new HashSet<Vehicle>(AllVehicles.Select(x => x.FrontCar).Where(x => x != null))).Count);
        }
    }
}