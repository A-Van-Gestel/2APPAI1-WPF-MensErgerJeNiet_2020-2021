using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace MensErgerJeNiet.Model
{
    class ColorDataService
    {
        // Internal list of colors for dupe detection
        private ObservableCollection<Color> colors;
        private ObservableCollection<PlayerHistory> playerHistories;

        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;


        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        // Get All Colors in a List
        public ObservableCollection<Color> GetColors()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Color order by Name";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van colors
            return new ObservableCollection<Color>((List<Color>)db.Query<Color>(sql));
        }

        // Get a Color by ID
        public Color GetColorByID(int id)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Color order by Name where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van colors
            return (Color)db.Query<Color>(sql, id);
        }

        // Update a Color
        public void UpdateColor(Color color)
        {
            // --- Dupe detection ---
            colors = GetColors();
            foreach (Color color_internal in colors)
            {
                if (color.Name == color_internal.Name &
                    color.Code == color_internal.Code)
                {
                    return;
                }
            }

            // --- If no dupe, update ---
            // SQL statement update 
            string sql = "Update Color set name = @name, code = @code where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                color.Name,
                color.Code,
                color.ID
            });
        }

        // Insert a Color
        public int InsertColor(Color color)
        {
            // --- Dupe detection ---
            colors = GetColors();
            foreach (Color color_internal in colors)
            {
                if (color.Name == color_internal.Name &
                    color.Code == color_internal.Code)
                {
                    return color_internal.ID;
                }
            }

            // --- If no dupe, instert ---
            // SQL statement insert
            string sql = "Insert into Color (name, code) values (@name, @code);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            var id = db.QuerySingle<int>(sql, new
            {
                color.Name,
                color.Code
            });
            return id;
        }

        // Delete a Color
        public void DeleteColor(Color color)
        {
            // --- Minum 4 detection ---
            colors = GetColors();
            if (colors.Count > 4)
            {
                // --- Usage detection ---
                //playerHistories inlezen
                PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
                playerHistories = playerHistoryDataService.GetPlayerHistories();
                foreach (PlayerHistory playerHistory_internal in playerHistories)
                {
                    if (color.ID == playerHistory_internal.ColorID)
                    {
                        return;
                    }
                }

                // --- If no usage, delete ---
                // SQL statement delete 
                string sql = "Delete Color where id = @id";

                // Uitvoeren SQL statement en doorgeven parametercollectie
                db.Execute(sql, new { color.ID });
            }
        }
    }
}
