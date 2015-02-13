

using System.Diagnostics.Contracts;
public class Vehicle : Object 
{

    public int Speed    { get; private set; }
    public Vehicle FollowedBy { get;  private set; }
    public Vehicle Following { get; set; }
    public float FuelLevel {get; private set;}
    public Navigator TheNavigator { get; private set; }
    public Brand CarBrand { get; private set; }
    public Vehicle() { }


    public void CreateConvoy()
    {
    }

    [ContractInvariantMethod]
    void ObjectInvariant()
    {
        Contract.Invariant(this.Following == null ||
                          (this.Following.FollowedBy == this && 
                           this.TheNavigator.IsActive) );

        Contract.Invariant(this.FollowedBy == null || 
                          (this.FollowedBy.Following == this && 
                            (this.Following == null || 
                            !this.TheNavigator.IsActive)));
    }

}