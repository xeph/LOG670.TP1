using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LOG670.TP1.Classes
{
    public class Highway {
        public Highway(List<Lane> lanes, int length, int maxSpeed, int minSpeed)
        {
            Lanes = lanes;
            Length = length;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
        }

        public List<Lane> Lanes { get; private set; }
        public int Length { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MinSpeed { get; private set; }

        public void ChangeLane(Vehicle vehicle, Lane desiredLane)
        {
            //pre LaneNotCurrentLane: not (self.lane = lane)
            Contract.Requires(!desiredLane.Objects.Contains(vehicle));
            //post LaneNowCurrentLane: self.lane = lane
            //post LaneNotOldLane: not (self.lane = self.lane@pre)
            Contract.Ensures(desiredLane.Objects.Contains(vehicle));
            Contract.Ensures(!Lanes.Exists(lane => lane.Objects.Contains(vehicle)));
            Contract.EndContractBlock();

            Lanes.Find(lane => lane.Objects.Contains(vehicle)).Objects.Remove(vehicle);
            Lanes.Find(lane => lane == desiredLane).Objects.Add(vehicle);
        }
    
    }
}