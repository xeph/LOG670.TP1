namespace LOG670.TP1.Classes
{
    public class CheckEngine {
        public CheckEngine(bool isOk)
        {
            IsOk = isOk;
        }

        public bool IsOk { get; private set; }
         
    }
}