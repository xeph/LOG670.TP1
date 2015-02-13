using System.Collections.Generic;

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
    
    }
}