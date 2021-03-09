namespace Flyingdot.Elgato.Keylight
{
    public class Temperature
    {
        public static int FromKelvinToMired(int valueInK)
        {
            return 1000000/valueInK; 
        }
    }
}
