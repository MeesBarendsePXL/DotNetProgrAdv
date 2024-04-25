﻿using DartApp.AppLogic.Contracts;
using DartApp.Domain;
using DartApp.Domain.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DartApp.Infrastructure.Storage
{
    internal class PlayerFileRepository : IPlayerRepository
    {
        private readonly string _playerFileDirectory;

        public PlayerFileRepository(string playerFileDirectory)
        {
            _playerFileDirectory = playerFileDirectory;
            if(!Directory.Exists(_playerFileDirectory))
            {
                Directory.CreateDirectory(_playerFileDirectory);
            }
        }

        public void Add(IPlayer player)
        {
            SavePlayer(player);
        }

        public IReadOnlyList<IPlayer> GetAll()
        {
            //TODO: read all player files in the directory, convert them to IPlayer objects and return them
            //Tip: use helper methods that are given (ReadPlayerloadFromFile)

            List<IPlayer> result = new List<IPlayer>();
            foreach (String path in Directory.GetFiles(_playerFileDirectory))
            {

                result.Add(ReadPlayerFromFile(path));
            }
            return result;
        }

        public void SaveChanges(IPlayer player)
        {
            SavePlayer(player);
        }


        private IPlayer ReadPlayerFromFile(string playerFilePath)
        {
            //TODO: read the json in a player file and deserialize the json into an IPlayer object
            //Tip: use helper methods that are given (ConvertJsonToPlayer)

            StreamReader reader = new StreamReader(playerFilePath);
            String str = reader.ReadToEnd();
            reader.Close();
            return ConvertJsonToPlayer(str);
        }

        private void SavePlayer(IPlayer player)
        {
            //TODO: save the player in a json format in a file
            //Tip: use helper methods that are given (GetPLayerilePath, ConvertPlayerToJson)

            StreamWriter writer = new StreamWriter(GetPlayerFilePath(player.Id));
            writer.Write(ConvertPlayerToJson(player));
            writer.Close();
            

        }

        private string ConvertPlayerToJson(IPlayer player)
        {
            string json = JsonConvert.SerializeObject(player, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            return json;
        }

        private IPlayer ConvertJsonToPlayer(string json)
        {
            IPlayer? player =  JsonConvert.DeserializeObject<Player>(json, new JsonSerializerSettings
            {
                ContractResolver = new JsonAllowPrivateSetterContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.Auto
            }) as IPlayer;
            return player!;
        }

        private string GetPlayerFilePath(Guid playerId)
        {
            string fileName = $"Player_{playerId}.json";
            return Path.Combine(_playerFileDirectory, fileName);
        }
    }
}
