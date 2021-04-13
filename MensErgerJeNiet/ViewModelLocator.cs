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
        private static HomeViewModel homeViewModel = new HomeViewModel();
        private static SpelRegelsViewModel spelRegelsViewModel = new SpelRegelsViewModel();
        private static PlayerSelectionViewModel playerSelectionViewModel = new PlayerSelectionViewModel();
        private static PlayViewModel playViewModel = new PlayViewModel();
        private static HistoryViewModel historyViewModel = new HistoryViewModel();
        // --- Admin Tools ---
        private static AdminViewModel adminViewModel = new AdminViewModel();
        private static AdminColorsViewModel adminColorsViewModel = new AdminColorsViewModel();
        private static AdminGamesViewModel adminGamesViewModel = new AdminGamesViewModel();
        private static AdminPlayersViewModel adminPlayersViewModel = new AdminPlayersViewModel();
        private static AdminPositionsViewModel adminPositionsViewModel = new AdminPositionsViewModel();
        private static AdminPlayerHistoriesViewModel adminPlayerHistoriesViewModel = new AdminPlayerHistoriesViewModel();

        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }

        public static SpelRegelsViewModel SpelRegelsViewModel
        {
            get
            {
                return spelRegelsViewModel;
            }
        }

        public static PlayerSelectionViewModel PlayerSelectionViewModel
        {
            get
            {
                return playerSelectionViewModel;
            }
        }

        public static PlayViewModel PlayViewModel
        {
            get
            {
                return playViewModel;
            }
        }

        public static HistoryViewModel HistoryViewModel
        {
            get
            {
                return historyViewModel;
            }
        }

        // --- Admin Tools ---
        public static AdminViewModel AdminViewModel
        {
            get
            {
                return adminViewModel;
            }
        }

        public static AdminColorsViewModel AdminColorsViewModel
        {
            get
            {
                return adminColorsViewModel;
            }
        }

        public static AdminGamesViewModel AdminGamesViewModel
        {
            get
            {
                return adminGamesViewModel;
            }
        }

        public static AdminPlayersViewModel AdminPlayersViewModel
        {
            get
            {
                return adminPlayersViewModel;
            }
        }

        public static AdminPositionsViewModel AdminPositionsViewModel
        {
            get
            {
                return adminPositionsViewModel;
            }
        }

        public static AdminPlayerHistoriesViewModel AdminPlayerHistoriesViewModel
        {
            get
            {
                return adminPlayerHistoriesViewModel;
            }
        }
    }
}
