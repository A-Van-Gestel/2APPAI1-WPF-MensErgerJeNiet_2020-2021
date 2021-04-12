using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class PositionDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Positions in a List
        public ObservableCollection<Position> GetPosition()
        {
            //// Stap 2 Dapper
            //// Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Position pos INNER JOIN PlayerHistory ph ON pos.PlayerHistoryID = ph.Id";

            //// Stap 3 Dapper
            //// Uitvoeren SQL statement op db instance 
            //// Type casten van het generieke return type naar een collectie van positions
            var positions = db.Query<Position, PlayerHistory, Position>(sql, (position, playerHistory) =>
            {
                position.PlayerHistory = playerHistory;
                return position;
            },
            splitOn: "Id");

            return new ObservableCollection<Position>((List<Position>)positions);
        }

        // Get a Position by ID
        public Position GetPositionByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Position where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van positions
            return (Position)db.Query<Position>(sql, id);
        }

        // Update a Position
        public void UpdatePosition(Position position)
        {
            // SQL statement update 
            string sql = "Update Position set playerHistoryID = @playerHistoryID, pion = @pion, coordinate = @coordinate, isHome = @isHome, isActive = @isActive where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                position.PlayerHistoryID,
                position.Pion,
                position.Coordinate,
                position.IsHome,
                position.IsActive,
                position.ID
            });
        }

        // Insert a Position
        public int InsertPosition(Position position)
        {
            // SQL statement insert
            string sql = "Insert into Position (playerHistoryID, pion, coordinate, isHome, isActive) values (@playerHistoryID, @pion, @coordinate, @isHome, @isActive);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new
            {
                position.PlayerHistoryID,
                position.Pion,
                position.Coordinate,
                position.IsHome,
                position.IsActive,
            });
            return id;
        }

        // Delete a Position
        public void DeletePosition(Position position)
        {
            // SQL statement delete 
            string sql = "Delete Position where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { position.ID });
        }
    }
}
