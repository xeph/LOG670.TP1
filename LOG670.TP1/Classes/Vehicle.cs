

public class Vehicle : Object 
{

    public int Speed    { get; private set; }
    public Vehicle FollowedBy { get;  private set; }
    public Vehicle Following { get; private set; }
    public float FuelLevel {get; private set;}
    public Navigator TheNavigator { get; private set; }
    public Brand CarBrand { get; private set; }
    public Vehicle() { }

}