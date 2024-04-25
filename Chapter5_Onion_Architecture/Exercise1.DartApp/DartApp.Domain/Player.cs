using DartApp.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DartApp.Domain
{
    public class Player : IPlayer
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<IGameResult> GameResults { get { return _gameResults; } }

        private List<IGameResult> _gameResults = new List<IGameResult>();

        private Player() { }

        public Player(String name) {

            if (name == String.Empty || name == null) throw new ArgumentException();
            Name = name;
            Id = Guid.NewGuid();

        }

        public void AddGameResult(IGameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public IPlayerStats GetPlayerStats()
        {
            int counter = 0;
            int best180 = 0;
            double avgThrow = 0;
            int bestThrow = 0;
            double avgBestThrow = 0;
            if (GameResults.Count < 1)
            {
                return new PlayerStats(0, 0, 0, 0);
            }

            foreach (IGameResult gameResult in _gameResults)
            {
                counter += 1;
                if (gameResult.NumberOf180 > best180)
                {
                    best180 = gameResult.NumberOf180;
                }
                if(gameResult.BestThrow > bestThrow)
                {
                    bestThrow = gameResult.BestThrow;
                }
                avgThrow += gameResult.AverageThrow;
                avgBestThrow += gameResult.BestThrow;
            }
           return new PlayerStats(best180,avgThrow/counter,bestThrow,avgBestThrow/counter);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            try
            {
                if( ((Player) obj).Name == Name )
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
