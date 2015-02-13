namespace LOG670.TP1.Classes
{
    public class Navigator {
        public Navigator(bool isActive, Destination theDestination, int cruiseSpeed, CheckEngine engine)
        {
            IsActive = isActive;
            TheDestination = theDestination;
            CruiseSpeed = cruiseSpeed;
            Engine = engine;
        }

        public bool IsActive { get; private set; }
        public Destination TheDestination { get; private set; }
        public int CruiseSpeed { get; private set; }
        public CheckEngine Engine { get; private set; }

    }
}