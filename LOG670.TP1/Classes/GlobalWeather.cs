namespace LOG670.TP1.Classes
{
    public class GlobalWeather {
        public GlobalWeather(float safeDistanceRatio)
        {
            SafeDistanceRatio = safeDistanceRatio;
        }

        public float SafeDistanceRatio { get; private set; }
   
    }
}