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
        public Vehicle FrontCar 
        {
            get
            {
                return (Following != null) ? Following.FrontCar : (FollowedBy != null) ? this : null;
            }
        }
        public Vehicle ConvoyLeader { get; set; }
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
            //pre VehicleStartingNotFollowed: self.ConvoyLeader.isUndefined 
            //pre VehicleStartingNoNavigator: self.navigator.isActive = false
            //pre VehicleEntryNotFollowing: vehicle.following.isUndefined 
            //pre VehicleEntryNoNavigator: vehicle.navigator.isActive = false 
            Contract.Requires(Following == null);
            Contract.Requires(ConvoyLeader == null);
            Contract.Requires(!TheNavigator.IsActive);
            Contract.Requires(vehicle.Following == null);
            Contract.Requires(!vehicle.TheNavigator.IsActive);
            //post VehicleStartedNotFollowing: self.ConvoyLeader.isUndefined 
            //post VehicleStartedFollowed: self.following = vehicle
            //post VehicleStartedNoNavigator: self.navigator.isActive = false
            //post VehicleEnteredFollowing: vehicle.ConvoyLeader = self
            //post VehicleEnteredNavigatorOn: vehicle.navigator.isActive=true
            Contract.Ensures(ConvoyLeader == vehicle);
            Contract.Ensures(Following == vehicle);
            Contract.Ensures(!TheNavigator.IsActive);
            Contract.Ensures(vehicle.ConvoyLeader == vehicle);
            Contract.Ensures(vehicle.TheNavigator.IsActive);
            Contract.EndContractBlock();

            Following = vehicle;
            ConvoyLeader = vehicle;
            vehicle.ConvoyLeader = vehicle;
            vehicle.TheNavigator.IsActive = true;
            vehicle.FollowedBy = this;
            
            
        }

        /// <summary>
        /// Te join au convoy du véhicule recu
        /// </summary>
        /// <param name="vehicle">le véhicule qui fait partie du convoi que tu veut te joindre à</param>
        public void JoinConvoy(Vehicle vehicle)
        {
            //pre ConvoyLeaderFollowingSomeone: not (vehicle.ConvoyLeader.isUndefined)
            //pre ConvoyLeaderFollowedByNobody: vehicle.followed.isUndefined //TODO: wtf?
            //pre VehicleEntryNotNull: not(vehicle.isUnderfined)
            //pre ConvoyLeaderNaviOn: vehicle.ConvoyLeader.navigator.isActive
            //pre VehicleEntryFollowingNoOne: self.ConvoyLeader.isUndefined
            //pre VehicleEntryNoNavigator: not(self.navigator.isActive)
            Contract.Requires(vehicle.ConvoyLeader != null);
            Contract.Requires(vehicle != null);
            Contract.Requires(vehicle.Following == null);
            Contract.Requires(vehicle.TheNavigator.IsActive);
            Contract.Requires(ConvoyLeader == null);
            Contract.Requires(!TheNavigator.IsActive);
            //post ConvoyLeaderStillFollowingSomeone: not (vehicle.ConvoyLeader.isUndefined)
            //post VehicleNowFollowedBySelf: vehicle.followedBy = self
            //post ConvoyLeaderNaviStillOn: vehicle.ConvoyLeader.navigator.isActive
            //post VehicleEntryNowFollowingSomeone: not(self.following.isUndefined)
            //post VehicleEntryNowNavigatorOn: self.navigator.isActive
            Contract.Ensures(vehicle.ConvoyLeader != null);
            Contract.Ensures(vehicle.FollowedBy == this);
            Contract.Ensures(vehicle.ConvoyLeader.TheNavigator.IsActive);
            Contract.Ensures(Following != null);
            Contract.Ensures(TheNavigator.IsActive);
            Contract.EndContractBlock();

            vehicle.FollowedBy = this;
            Following = vehicle;
            ConvoyLeader = vehicle.ConvoyLeader;
            TheNavigator.IsActive = true;
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
            //pre VehicleIsFollowing: not(self.ConvoyLeader.isUndefined)
            //pre VehicleHeadFollowed: not(self.ConvoyLeader.followedBy.isUndefined)
            //pre VehicleStartedNoNavigator: self.navigator.isActive
            Contract.Requires(ConvoyLeader != null);
            Contract.Requires(ConvoyLeader.FollowedBy != null);
            Contract.Requires(TheNavigator.IsActive);
            //post SelfNoLongerFollowedBy: not Vehicle.allInstances->exists(v | v.following = self)
            //post VehicleLeavingNoNavigator: not(self.navigator.isActive)
            //post VehicleLeavingNotFollowing: self.ConvoyLeader.isUndefined
            //Contract.Ensures((ConvoyLeader == null || !IsVehicleInConvoy(ConvoyLeaderReference, this))); //TODO: Can't access other vehicles once you've left the convoy. How do I check this?
            Contract.Ensures(!TheNavigator.IsActive);
            Contract.EndContractBlock();

            //If this is the front car, set car following you to front car, and update all following vehicles.
            if (ConvoyLeader == this)
            {
                SetAllCarsConvoyLeader(this.FollowedBy, this.FollowedBy);
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
            ConvoyLeader = null;
            TheNavigator.IsActive = false;
        }

        private void SetAllCarsConvoyLeader(Vehicle newConvoyLeader, Vehicle followingVehicle)
        {
            followingVehicle.ConvoyLeader = newConvoyLeader;
            if (followingVehicle.FollowedBy != null)
            {
                SetAllCarsConvoyLeader(newConvoyLeader, followingVehicle.FollowedBy);
            }
        }

        /// <summary>
        /// Méthode récursive qui verifie si le véhicule est dans le convoie TODO: aurais besoin access au convoie pour verifier
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