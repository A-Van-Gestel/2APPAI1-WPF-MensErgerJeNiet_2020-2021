using MensErgerJeNiet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    class ViewModelLocator
    {
        // Resulted in old data getting to the view the 'Read data from database' command is only run at startup.

        //private static HomeViewModel homeViewModel = new HomeViewModel();
        //private static SpelRegelsViewModel spelRegelsViewModel = new SpelRegelsViewModel();
        //private static PlayerSelectionViewModel playerSelectionViewModel = new PlayerSelectionViewModel();
        //private static PlayViewModel playViewModel = new PlayViewModel();
        //private static HistoryViewModel historyViewModel = new HistoryViewModel();
        //// --- Admin Tools ---
        //private static AdminViewModel adminViewModel = new AdminViewModel();
        //private static AdminColorsViewModel adminColorsViewModel = new AdminColorsViewModel();
        //private static AdminGamesViewModel adminGamesViewModel = new AdminGamesViewModel();
        //private static AdminPlayersViewModel adminPlayersViewModel = new AdminPlayersViewModel();
        //private static AdminPositionsViewModel adminPositionsViewModel = new AdminPositionsViewModel();
        //private static AdminPlayerHistoriesViewModel adminPlayerHistoriesViewModel = new AdminPlayerHistoriesViewModel();

        public static HomeViewModel HomeViewModel
        {
            get
            {
                return new HomeViewModel();
            }
        }

        public static SpelRegelsViewModel SpelRegelsViewModel
        {
            get
            {
                return new SpelRegelsViewModel();
            }
        }

        public static PlayerSelectionViewModel PlayerSelectionViewModel
        {
            get
            {
                return new PlayerSelectionViewModel();
            }
        }

        public static PlayViewModel PlayViewModel
        {
            get
            {
                return new PlayViewModel();
            }
        }

        public static HistoryViewModel HistoryViewModel
        {
            get
            {
                return new HistoryViewModel();
            }
        }

        // --- Admin Tools ---
        public static AdminViewModel AdminViewModel
        {
            get
            {
                return new AdminViewModel();
            }
        }

        public static AdminColorsViewModel AdminColorsViewModel
        {
            get
            {
                return new AdminColorsViewModel();
            }
        }

        public static AdminGamesViewModel AdminGamesViewModel
        {
            get
            {
                return new AdminGamesViewModel();
            }
        }

        public static AdminPlayersViewModel AdminPlayersViewModel
        {
            get
            {
                return new AdminPlayersViewModel();
            }
        }

        public static AdminPositionsViewModel AdminPositionsViewModel
        {
            get
            {
                return new AdminPositionsViewModel();
            }
        }

        public static AdminPlayerHistoriesViewModel AdminPlayerHistoriesViewModel
        {
            get
            {
                return new AdminPlayerHistoriesViewModel();
            }
        }
    }
}
