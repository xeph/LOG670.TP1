namespace LOG670.TP1.Classes
{
    public class Navigator {
        public Navigator(Destination theDestination, int cruiseSpeed = 1)
        {
            IsActive = false;
            TheDestination = theDestination;
            CruiseSpeed = cruiseSpeed;
            Engine = new CheckEngine();
        }

        public bool IsActive { get; set; }
        public Destination TheDestination { get; private set; }
        public int CruiseSpeed { get; private set; }
        public CheckEngine Engine { get; private set; }

        public void SetDestination(Destination destination)
        {
            TheDestination = destination;
        }
    }
}