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
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Games in a List
        public ObservableCollection<Game> GetGame()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Game g INNER JOIN PlayerHistory ph ON g.PlayerHistoryID = ph.Id order by Date";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van games
            var games = db.Query<Game, PlayerHistory, Game>(sql, (game, playerHistory) =>
            {
                game.PlayerHistory = playerHistory;
                return game;
            },
            splitOn: "Id");

            return new ObservableCollection<Game>((List<Game>)games);
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
            return (Game)db.Query<Game>(sql, id);
        }

        // Update a Game
        public void UpdateGame(Game game)
        {
            // SQL statement update 
            string sql = "Update Game set playerHistoryID = @playerHistoryID, date = @date, isActive = @isActive where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                game.PlayerHistoryID,
                game.Date,
                game.IsActive,
                game.ID
            });
        }

        // Insert a Game
        public void InsertGame(Game game)
        {
            // SQL statement insert
            string sql = "Insert into Game (playerHistoryID, date, isActive) values (@playerHistoryID, @date, @isActive)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                game.PlayerHistoryID,
                game.Date,
                game.IsActive
            });
        }

        // Delete a Game
        public void DeleteGame(Game game)
        {
            // SQL statement delete 
            string sql = "Delete Game where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { game.ID });
        }
    }
}
