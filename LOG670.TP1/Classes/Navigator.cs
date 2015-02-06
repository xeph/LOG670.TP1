public class Navigator {

    public bool IsActive { get; private set; }
    public Destination TheDestination { get; private set; }
    public int CruiseSpeed { get; private set; }
    public CheckEngine Engine { get; private set; }

}