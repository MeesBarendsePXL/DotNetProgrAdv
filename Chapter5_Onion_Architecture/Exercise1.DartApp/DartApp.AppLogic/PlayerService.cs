using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace DartApp.AppLogic
{
    internal class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository player) {
        _playerRepository = player;
        }

        public void AddGameResultForPlayer(IPlayer player, int number180, double average, int bestThrow)
        {
           player.AddGameResult(new GameResult(player.Id,number180, average,bestThrow));
            _playerRepository.SaveChanges(player);
        }

        public IPlayer AddPlayer(string playerName)
        {
            Player player = new Player(playerName);
           
            _playerRepository.Add(player);
            return player;
        }

        public IReadOnlyList<IPlayer> GetAllPlayers()
        {
            return _playerRepository.GetAll();
        }

        public IPlayerStats GetStatsForPlayer(IPlayer player)
        {
            return player.GetPlayerStats();
        }
    }
}
