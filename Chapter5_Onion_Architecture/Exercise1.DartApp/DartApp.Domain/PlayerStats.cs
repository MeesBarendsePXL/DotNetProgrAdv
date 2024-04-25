using DartApp.Domain.Contracts;

namespace DartApp.Domain
{
    internal class PlayerStats : IPlayerStats
    {
        public double AverageThrow { get; set; }

        public int Total180 { get; set; }

        public int BestThrow { get; set; }

        public double AverageBestThrow { get; set; }

        public PlayerStats(int numberOf180, double averageThrow, int bestThrow, double averageBestThrow)
        {
            AverageThrow = averageThrow;
            BestThrow = bestThrow;
            Total180 = numberOf180;
            AverageBestThrow = averageBestThrow;
        }
        public override string ToString()
        {
            return "Average: " + AverageThrow.ToString("0.00") + "; 180s: " + Total180.ToString() + "; Best throw: " + BestThrow.ToString() + " (Average best throw: " + AverageBestThrow.ToString("0.00") + ")";
        }


    }
}
