namespace Exercise3
{
    public static class IntegerExtensions
    {
        public static int CircularIncrement(this int number , int min,int max)
        {
            number += 1;
            if (number >= max | number <= min) {
                return min;
            }
            return number;
        }
        //This class should contain an extension method 'CircularIncrement'. The method returns an integer incremented by 1.
        //But when the number to increment is a maximum value, the the returned number should be a minimum value.
    }
}