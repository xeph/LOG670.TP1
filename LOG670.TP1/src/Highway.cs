using System.Collections.Generic;

public class Highway {
    public List<Lane> lanes;
    private List<Lane> Lanes {
        get {
            return this.lanes;
        }
        set {
            this.lanes = value;
        }
    }
    
    public int length;
    private int Length {
        get {
            return this.length;
        }
        set {
            this.length = value;
        }
    }
    
    public int maxSpeed;
    private int MaxSpeed {
        get {
            return this.maxSpeed;
        }
        set {
            this.maxSpeed = value;
        }
    }
    
    public int minSpeed;
    private int MinSpeed {
        get {
            return this.minSpeed;
        }
        set {
            this.minSpeed = value;
        }
    }
    
    public Highway() { }
}