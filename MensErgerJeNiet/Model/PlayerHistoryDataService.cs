using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class PlayerHistoryDataService
    {
        // Internal list of playerHistories for dupe detection
        private ObservableCollection<PlayerHistory> playerHistories;

        // Intenal list of games for deletion prevention
        private ObservableCollection<Game> games;

        // Intenal lists for deletion
        private ObservableCollection<Player> players;
        private ObservableCollection<Position> positions;

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
            string sql = "Select * from PlayerHistory ph INNER JOIN Player pl ON ph.PlayerID = pl.Id INNER JOIN Color c ON ph.ColorID = c.Id INNER JOIN Game g ON ph.GameID = g.Id";

            //// Stap 3 Dapper
            //// Uitvoeren SQL statement op db instance 
            //// Type casten van het generieke return type naar een collectie van playerHistories
            var playerHistories = db.Query<PlayerHistory, Player, Color, Game, PlayerHistory>(sql, (playerHistory, player, color, game) =>
            {
                playerHistory.Player = player;
                playerHistory.Color = color;
                playerHistory.Game = game;
                return playerHistory;
            },
            splitOn: "Id");

            return new ObservableCollection<PlayerHistory>((List<PlayerHistory>)playerHistories);
        }

        public ObservableCollection<PlayerHistory> GetPlayerHistoriesFromWinners()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from PlayerHistory ph INNER JOIN Player pl ON ph.PlayerID = pl.Id INNER JOIN Color c ON ph.ColorID = c.Id INNER JOIN Game g ON ph.GameID = g.Id where isWinner = 1";

            //// Stap 3 Dapper
            //// Uitvoeren SQL statement op db instance 
            //// Type casten van het generieke return type naar een collectie van playerHistories
            var playerHistories = db.Query<PlayerHistory, Player, Color, Game, PlayerHistory>(sql, (playerHistory, player, color, game) =>
            {
                playerHistory.Player = player;
                playerHistory.Color = color;
                playerHistory.Game = game;
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
            return (PlayerHistory)db.QuerySingle<PlayerHistory>(sql, id);
        }

        // Update a PlayerHistory
        public void UpdatePlayerHistory(PlayerHistory playerHistory)
        {
            // --- Dupe detection ---
            playerHistories = GetPlayerHistories();
            foreach (PlayerHistory playerHistory_internal in playerHistories)
            {
                if (playerHistory.PlayerID == playerHistory_internal.PlayerID &
                    playerHistory.ColorID == playerHistory_internal.ColorID &
                    playerHistory.GameID == playerHistory_internal.GameID &
                    playerHistory.CountTime == playerHistory_internal.CountTime &
                    playerHistory.CountSixes == playerHistory_internal.CountSixes &
                    playerHistory.CountTurns == playerHistory_internal.CountTurns &
                    playerHistory.IsTurn == playerHistory_internal.IsTurn &
                    playerHistory.IsWinner == playerHistory_internal.IsWinner)
                {
                    return;
                }
            }

            // --- If no dupe, update ---
            // SQL statement update 
            string sql = "Update PlayerHistory set playerID = @playerID, colorID = @colorID, gameID = @gameID, countTime = @countTime, countSixes = @countSixes, countTurns = @countTurns, isTurn = @isTurn, isWinner = @isWinner where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                playerHistory.PlayerID,
                playerHistory.ColorID,
                playerHistory.GameID,
                playerHistory.CountTime,
                playerHistory.CountSixes,
                playerHistory.CountTurns,
                playerHistory.IsTurn,
                playerHistory.IsWinner,
                playerHistory.ID
            });
        }

        // Insert a PlayerHistory
        public int InsertPlayerHistory(PlayerHistory playerHistory)
        {
            // --- Dupe detection ---
            playerHistories = GetPlayerHistories();
            foreach (PlayerHistory playerHistory_internal in playerHistories)
            {
                if (playerHistory.PlayerID == playerHistory_internal.PlayerID &
                    playerHistory.ColorID == playerHistory_internal.ColorID &
                    playerHistory.GameID == playerHistory_internal.GameID &
                    playerHistory.CountTime == playerHistory_internal.CountTime &
                    playerHistory.CountSixes == playerHistory_internal.CountSixes &
                    playerHistory.CountTurns == playerHistory_internal.CountTurns &
                    playerHistory.IsTurn == playerHistory_internal.IsTurn &
                    playerHistory.IsWinner == playerHistory_internal.IsWinner)
                {
                    return playerHistory_internal.ID;
                }
            }

            // --- If no dupe, instert ---
            // SQL statement insert
            string sql = "Insert into PlayerHistory (playerID, colorID, gameID, countTime, countSixes, countTurns, isTurn, isWinner) values (@playerID, @colorID, @gameID, @countTime, @countSixes, @countTurns, @isTurn, @isWinner);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new
            {
                playerHistory.PlayerID,
                playerHistory.ColorID,
                playerHistory.GameID,
                playerHistory.CountTime,
                playerHistory.CountSixes,
                playerHistory.CountTurns,
                playerHistory.IsTurn,
                playerHistory.IsWinner,
            });
            return id;
        }

        // Delete a PlayerHistory
        public void DeletePlayerHistory(PlayerHistory playerHistory)
        {
            //// --- Usage detection ---
            ////games inlezen
            //GameDataService gameDataService = new GameDataService();
            //games = gameDataService.GetGames();
            //foreach (Game game_internal in games)
            //{
            //    if (playerHistory.GameID == game_internal.ID)
            //    {
            //        return;
            //    }
            //}

            // --- If no usage, delete positions linked to it, then itself, and finally players linked to it ---
            // - Delete positions linked to it -
            //positions inlezen
            PositionDataService positionDataService = new PositionDataService();
            positions = positionDataService.GetPositions();
            foreach (Position position_internal in positions)
            {
                if (playerHistory.ID == position_internal.PlayerHistoryID)
                {
                    positionDataService.DeletePosition(position_internal);
                }
            }


            // - Delete itself (PlayerHistory) -
            // SQL statement delete 
            string sql = "Delete PlayerHistory where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { playerHistory.ID });


            // - Delete players linked to it -
            //players inlezen
            PlayerDataService playerDataService = new PlayerDataService();
            players = playerDataService.GetPlayers();
            foreach (Player player_internal in players)
            {
                if (playerHistory.PlayerID == player_internal.ID)
                {
                    playerDataService.DeletePlayer(player_internal);
                }
            }
        }
    }
}
