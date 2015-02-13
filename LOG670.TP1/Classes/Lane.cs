using System.Collections.Generic;

namespace LOG670.TP1.Classes
{
    public class Lane {
        public Lane(List<Object> objects, List<Destination> allDestinations)
        {
            Objects = objects;
            AllDestinations = allDestinations;
        }

        public List<Object> Objects { get; private set; }
        public List<Destination> AllDestinations { get; private set; }
    
    }
}