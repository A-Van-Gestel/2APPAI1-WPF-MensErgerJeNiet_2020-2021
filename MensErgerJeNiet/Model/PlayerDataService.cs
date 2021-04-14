using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class PlayerDataService
    {
        // Internal list of players for dupe detection
        private ObservableCollection<Player> players;
        private ObservableCollection<PlayerHistory> playerHistories;

        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Players in a List
        public ObservableCollection<Player> GetPlayers()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Player order by Name";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van players
            return new ObservableCollection<Player>((List<Player>)db.Query<Player>(sql));
        }

        // Get a Player by ID
        public Player GetPlayerByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Player order by Name where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van players
            return (Player)db.QuerySingle<Player>(sql, id);
        }

        // Update a Player
        public void UpdatePlayer(Player player)
        {
            // --- Dupe detection ---
            players = GetPlayers();
            foreach (Player player_internal in players)
            {
                if (player.Name == player_internal.Name)
                {
                    return;
                }
            }

            // --- If no dupe, update ---
            // SQL statement update 
            string sql = "Update Player set name = @name where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                player.Name,
                player.ID
            });
        }

        // Insert a Player
        public int InsertPlayer(Player player)
        {
            // --- Dupe detection ---
            players = GetPlayers();
            foreach (Player player_internal in players)
            {
                if (player.Name == player_internal.Name)
                {
                    return player_internal.ID;
                }
            }

            // --- If no dupe, instert ---
            // SQL statement insert
            string sql = "Insert into Player (name) values (@name);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new { player.Name });
            return id;
        }

        // Delete a Player
        public void DeletePlayer(Player player)
        {
            // --- Usage detection ---
            //playerHistories inlezen
            PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
            playerHistories = playerHistoryDataService.GetPlayerHistories();
            foreach (PlayerHistory playerHistory_internal in playerHistories)
            {
                if (player.ID == playerHistory_internal.PlayerID)
                {
                    return;
                }
            }

            // --- If no usage, delete ---
            // SQL statement delete 
            string sql = "Delete Player where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { player.ID });
        }
    }
}
