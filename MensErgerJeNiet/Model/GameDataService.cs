using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class GameDataService
    {
        // Internal list of games for dupe detection
        private ObservableCollection<Game> games;
        private ObservableCollection<PlayerHistory> playerHistories;

        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Games in a List
        public ObservableCollection<Game> GetGames()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Game order by Date";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van players
            return new ObservableCollection<Game>((List<Game>)db.Query<Game>(sql));
        }

        // Get a Game by ID
        public Game GetGameByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Game order by Date where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van colors
            return (Game)db.QuerySingle<Game>(sql, id);
        }

        // Get the ID of the latest Game
        public int GetIDfromLatestGame()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Game;" + "SELECT CAST(SCOPE_IDENTITY() as int)"; ;

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van colors
            var id = db.QuerySingle<int>(sql);
            return id;
        }

        // Update a Game
        public void UpdateGame(Game game)
        {
            // --- Dupe detection ---
            games = GetGames();
            foreach (Game game_internal in games)
            {
                if (game.Date == game_internal.Date &
                    game.IsActive == game_internal.IsActive)
                {
                    return;
                }
            }

            // --- If no dupe, update ---
            // SQL statement update 
            string sql = "Update Game set date = @date, isActive = @isActive where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                game.Date,
                game.IsActive,
                game.ID
            });
        }

        // Insert a Game
        public int InsertGame(Game game)
        {
            // --- Dupe detection ---
            games = GetGames();
            foreach (Game game_internal in games)
            {
                if (game.Date == game_internal.Date &
                    game.IsActive == game_internal.IsActive)
                {
                    return game_internal.ID;
                }
            }

            // --- If no dupe, instert ---
            // SQL statement insert
            string sql = "Insert into Game (date, isActive) values (@date, @isActive);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new { game.Date, game.IsActive });
            return id;
        }

        // Delete a Game
        public void DeleteGame(Game game)
        {
            // --- Delete playerHistory linked to it as well ---
            //playerHistories inlezen
            PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
            playerHistories = playerHistoryDataService.GetPlayerHistories();
            foreach (PlayerHistory playerHistory_internal in playerHistories)
            {
                if (game.ID == playerHistory_internal.GameID)
                {
                    playerHistoryDataService.DeletePlayerHistory(playerHistory_internal);
                }
            }

            // --- Then delete the game ---
            // SQL statement delete 
            string sql = "Delete Game where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { game.ID });
        }
    }
}
