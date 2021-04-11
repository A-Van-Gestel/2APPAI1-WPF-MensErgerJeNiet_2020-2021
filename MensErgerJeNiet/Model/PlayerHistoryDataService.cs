﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class PlayerHistoryDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All playerHistories in a List
        public ObservableCollection<PlayerHistory> GetPlayerHistories()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from PlayerHistory ph INNER JOIN Player pl ON ph.PlayerID = pl.Id INNER JOIN Color c ON ph.ColorID = c.Id";

            //// Stap 3 Dapper
            //// Uitvoeren SQL statement op db instance 
            //// Type casten van het generieke return type naar een collectie van playerHistories
            var playerHistories = db.Query<PlayerHistory, Player, Color, PlayerHistory>(sql, (playerHistory, player, color) =>
            {
                playerHistory.Player = player;
                playerHistory.Color = color;
                return playerHistory;
            },
            splitOn: "Id");

            return new ObservableCollection<PlayerHistory>((List<PlayerHistory>)playerHistories);
        }

        // Get a PlayerHistory by ID
        public PlayerHistory GetPlayerHistoriesByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from PlayerHistory order by PlayerID where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van colors
            return (PlayerHistory)db.Query<PlayerHistory>(sql, id);
        }

        // Update a PlayerHistory
        public void UpdatePlayerHistory(PlayerHistory playerHistory)
        {
            // SQL statement update 
            string sql = "Update PlayerHistory set playerID = @playerID, colorID = @colorID, countTime = @countTime, countSixes = @countSixes, countTurns = @countTurns, isTurn = @isTurn where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                playerHistory.PlayerID,
                playerHistory.ColorID,
                playerHistory.CountTime,
                playerHistory.CountSixes,
                playerHistory.CountTurns,
                playerHistory.IsTurn,
                playerHistory.ID
            });
        }

        // Insert a PlayerHistory
        public void InsertPlayerHistory(PlayerHistory playerHistory)
        {
            // SQL statement insert
            string sql = "Insert into PlayerHistory (playerID, colorID, countTime, countSixes, countTurns, isTurn) values (@playerID, @colorID, @countTime, @countSixes, @countTurns, @isTurn)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                playerHistory.PlayerID,
                playerHistory.ColorID,
                playerHistory.CountTime,
                playerHistory.CountSixes,
                playerHistory.CountTurns,
                playerHistory.IsTurn,
            });
        }

        // Delete a PlayerHistory
        public void DeletePlayerHistory(PlayerHistory playerHistory)
        {
            // SQL statement delete 
            string sql = "Delete PlayerHistory where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { playerHistory.ID });
        }
    }
}
