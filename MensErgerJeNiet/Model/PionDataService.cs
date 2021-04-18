using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class PionDataService
    {
        // Internal list of pions for dupe detection
        private ObservableCollection<Pion> pions;

        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Pions in a List
        public ObservableCollection<Pion> GetPions()
        {
            //// Stap 2 Dapper
            //// Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Pion pos INNER JOIN PlayerHistory ph ON pos.PlayerHistoryID = ph.Id";

            //// Stap 3 Dapper
            //// Uitvoeren SQL statement op db instance 
            //// Type casten van het generieke return type naar een collectie van pions
            var pions = db.Query<Pion, PlayerHistory, Pion>(sql, (pion, playerHistory) =>
            {
                pion.PlayerHistory = playerHistory;
                return pion;
            },
            splitOn: "Id");

            return new ObservableCollection<Pion>((List<Pion>)pions);
        }

        // Get a Pion by ID
        public Pion GetPionByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Pion where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van pions
            return (Pion)db.Query<Pion>(sql, new { id });
        }

        // Update a Pion
        public void UpdatePion(Pion pion)
        {
            // --- Dupe detection ---
            pions = GetPions();
            foreach (Pion pion_internal in pions)
            {
                if (pion.PlayerHistoryID == pion_internal.PlayerHistoryID &
                    pion.PionNr == pion_internal.PionNr &
                    pion.Coordinate == pion_internal.Coordinate &
                    pion.IsHome == pion_internal.IsHome &
                    pion.IsActive == pion_internal.IsActive)
                {
                    return;
                }
            }

            // --- If no dupe, update ---
            // SQL statement update 
            string sql = "Update Pion set playerHistoryID = @playerHistoryID, pion = @pion, coordinate = @coordinate, isHome = @isHome, isActive = @isActive where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                pion.PlayerHistoryID,
                pion.PionNr,
                pion.Coordinate,
                pion.IsHome,
                pion.IsActive,
                pion.ID
            });
        }

        // Insert a Pion
        public int InsertPion(Pion pion)
        {
            // --- Dupe detection ---
            pions = GetPions();
            foreach (Pion pion_internal in pions)
            {
                if (pion.PlayerHistoryID == pion_internal.PlayerHistoryID &
                    pion.PionNr == pion_internal.PionNr &
                    pion.Coordinate == pion_internal.Coordinate &
                    pion.IsHome == pion_internal.IsHome &
                    pion.IsActive == pion_internal.IsActive)
                {
                    return pion_internal.ID;
                }
            }

            // --- If no dupe, instert ---
            // SQL statement insert
            string sql = "Insert into Pion (playerHistoryID, pion, coordinate, isHome, isActive) values (@playerHistoryID, @pion, @coordinate, @isHome, @isActive);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new
            {
                pion.PlayerHistoryID,
                pion.PionNr,
                pion.Coordinate,
                pion.IsHome,
                pion.IsActive,
            });
            return id;
        }

        // Delete a Pion
        public void DeletePion(Pion pion)
        {
            // SQL statement delete 
            string sql = "Delete Pion where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { pion.ID });
        }
    }
}
