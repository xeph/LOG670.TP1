public class Vehicle {
    private int speed;
    public int Speed {
        get {
            return this.speed;
        }
        set {
            this.speed = value;
        }
    }
    
    private Vehicle followedBy;
    public Vehicle FollowedBy {
        get {
            return this.followedBy;
        }
        set {
            this.followedBy = value;
        }
    }
    
    private Vehicle following;
    public Vehicle Following {
        get {
            return this.following;
        }
        set {
            this.following = value;
        }
    }
    
    private float fuelLevel;
    public float FuelLevel {
        get {
            return this.fuelLevel;
        }
        set {
            this.fuelLevel = value;
        }
    }
    
    private Navigator theNavigator;
    public Navigator TheNavigator {
        get {
            return this.theNavigator;
        }
        set {
            this.theNavigator = value;
        }
    }
    
    private Brand theBrand;
    public Brand TheBrand {
        get {
            return this.theBrand;
        }
        set {
            this.theBrand = value;
        }
    }
    
    public Vehicle() { }
}