using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace LOG670.TP1.Classes
{
    public class Lane {

        public Lane(List<Object> objects, List<Destination> allDestinations, int identifier)
        {
            Objects = objects;
            AllDestinations = allDestinations;
            Identifier = identifier;
        }

        public int Identifier { get; private set; }
        public List<Object> Objects { get; private set; }
        public List<Destination> AllDestinations { get; private set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant((new HashSet<int>(Objects.Select(x => x.Position))).Count == Objects.Count);
        }

    }
}