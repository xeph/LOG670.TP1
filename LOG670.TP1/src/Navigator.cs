public class Navigator {
    private bool isActive;
    public bool IsActive {
        get {
            return this.isActive;
        }
        set {
            this.isActive = value;
        }
    }
    
    private Destination theDestination;
    public Destination TheDestination {
        get {
            return this.theDestination;
        }
        set {
            this.theDestination = value;
        }
    }
    
    private int cruiseSpeed;
    public int CruiseSpeed {
        get {
            return this.cruiseSpeed;
        }
        set {
            this.cruiseSpeed = value;
        }
    }
    
    private CheckEngine engine;
    public CheckEngine Engine {
        get {
            return this.engine;
        }
        set {
            this.engine = value;
        }
    }
    
    public Navigator() { }
}