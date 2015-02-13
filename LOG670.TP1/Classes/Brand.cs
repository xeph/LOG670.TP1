namespace LOG670.TP1.Classes
{
    public class Brand {
        public Brand(int length, string name)
        {
            Length = length;
            Name = name;
        }

        public int Length { get; private set; }
        public string Name { get; private set; }
          
    }
}