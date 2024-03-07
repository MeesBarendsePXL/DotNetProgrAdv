using System;
using System.Drawing;

namespace Exercise1
{
    public static class RandomExtensions
    {
        public static Balloon NextBalloon(this Random random,int maxSize)
        {
            return new Balloon(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)),random.Next(maxSize));
        }

        public static Balloon NextBalloonFromArray(this Random random, Balloon[] balloons){
            return balloons.ElementAt(random.Next(balloons.Count()));
        }
    }
}
