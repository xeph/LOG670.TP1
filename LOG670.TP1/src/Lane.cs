using System.Collections.Generic;

public class Lane {
    private List<Object> objects;
    public List<Object> Objects {
        get {
            return this.objects;
        }
        set {
            this.objects = value;
        }
    }
    
    private List<Destination> allDestination;
    public List<Destination> AllDestination {
        get {
            return this.allDestination;
        }
        set {
            this.allDestination = value;
        }
    }
    
    public Lane() { }
}