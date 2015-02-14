namespace LOG670.TP1.Classes
{
    public class Destination {
        public Destination(int position, bool hasGazStation)
        {
            Position = position;
            HasGazStation = hasGazStation;
        }

        public int Position { get; private set; }
        public bool HasGazStation { get; private set; }

    }
}