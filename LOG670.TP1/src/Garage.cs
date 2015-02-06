using System.Collections.Generic;

public class Garage {
    private List<Brand> canRepair;
    public List<Brand> CanRepair {
        get {
            return this.canRepair;
        }
        set {
            this.canRepair = value;
        }
    }
    
    public Garage() { }
}