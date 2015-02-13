namespace LOG670.TP1.Classes
{
public class Vehicle : Object 
{
        public Vehicle(int position, int speed, Vehicle followedBy, Vehicle following, float fuelLevel,
            Navigator theNavigator, Brand carBrand) : base(position)
        {
            Speed = speed;
            FollowedBy = followedBy;
            Following = following;
            FuelLevel = fuelLevel;
            TheNavigator = theNavigator;
            CarBrand = carBrand;
        }

        public int Speed { get; private set; }
        public Vehicle FollowedBy { get; private set; }
        public Vehicle Following { get; private set; }
        public float FuelLevel { get; private set; }
    public Navigator TheNavigator { get; private set; }
    public Brand CarBrand { get; private set; }



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
}