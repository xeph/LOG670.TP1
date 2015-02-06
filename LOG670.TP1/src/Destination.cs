public class Destination {
    private int position;
    public int Position {
        get {
            return this.position;
        }
        set {
            this.position = value;
        }
    }
    
    private bool hasGazStation;
    public bool HasGazStation {
        get {
            return this.hasGazStation;
        }
        set {
            this.hasGazStation = value;
        }
    }
    
    public Destination() { }
}