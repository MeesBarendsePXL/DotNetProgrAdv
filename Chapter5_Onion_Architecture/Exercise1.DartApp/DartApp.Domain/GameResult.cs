using DartApp.Domain.Contracts;
using System;

namespace DartApp.Domain
{
    public class GameResult : IGameResult
    {
        public Guid Id {  get; private set; }

        public Guid PlayerId { get; private set; }

        public int NumberOf180 { get; private set; }

        public double AverageThrow { get; private set; }

        public int BestThrow { get; private set; }

        private GameResult() { }


        public GameResult(Guid id, int numberOf180, double averageThrow, int bestThrow)
        {
            if(numberOf180 > 0 && bestThrow > numberOf180)
            {
                throw new ArgumentException();
            }
            if(averageThrow > bestThrow || bestThrow > 180)
            {
                throw new ArgumentException();
            }
            if (numberOf180 >= 0 && averageThrow >= 0 && bestThrow >= 0)
            {
                PlayerId = id;
                NumberOf180 = numberOf180;
                AverageThrow = averageThrow;
                BestThrow = bestThrow;
                Id = Guid.NewGuid();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return "Average: " + AverageThrow.ToString("0.00") + "; 180s: " + NumberOf180.ToString() + "; Best: " + BestThrow.ToString();
        }

    }
}
