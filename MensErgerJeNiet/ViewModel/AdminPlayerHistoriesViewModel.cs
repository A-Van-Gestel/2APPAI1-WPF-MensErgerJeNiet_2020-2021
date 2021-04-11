using MensErgerJeNiet.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminPlayerHistoriesViewModel : BaseViewModel
    {
        public AdminPlayerHistoriesViewModel()
        {
            LeesPlayerHistory();
            KoppelenCommands();
        }

        private ObservableCollection<PlayerHistory> playerHistories;
        public ObservableCollection<PlayerHistory> PlayerHistories
        {
            get
            {
                return playerHistories;
            }

            set
            {
                playerHistories = value;
                NotifyPropertyChanged();
            }
        }

        private PlayerHistory currentPlayerHistory;
        public PlayerHistory CurrentPlayerHistory
        {
            get
            {
                if (currentPlayerHistory == null)
                {
                    currentPlayerHistory = new PlayerHistory();
                }
                return currentPlayerHistory;
            }

            set
            {
                currentPlayerHistory = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenPlayerHistory);
            VerwijderenCommand = new BaseCommand(VerwijderenPlayerHistory);
            ToevoegenCommand = new BaseCommand(ToevoegenPlayerHistory);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void LeesPlayerHistory()
        {
            //instantiëren dataservice
            PlayerHistoryDataService contactDS =
               new PlayerHistoryDataService();

            PlayerHistories = new ObservableCollection<PlayerHistory>(contactDS.GetPlayerHistories());




            //Players inlezen
            PlayerDataService playerDataService = new PlayerDataService();
            Players = playerDataService.GetPlayers();

            //Colors inlezen
            ColorDataService colorDataService = new ColorDataService();
            Colors = colorDataService.GetColors();

            //Games inlezen
            GameDataService gameDataService = new GameDataService();
            Games = gameDataService.GetGames();

            foreach (PlayerHistory playerHistory in PlayerHistories)
            {
                //Relatie Players
                if (playerHistory.PlayerID > 0)
                {
                    SelectedPlayer = Players.FirstOrDefault(pl => pl.ID == playerHistory.PlayerID);
                }

                //Relatie Colors
                if (playerHistory.ColorID > 0)
                {
                    SelectedColor = Colors.FirstOrDefault(c => c.ID == playerHistory.ColorID);
                }

                //Relatie Games
                if (playerHistory.GameID > 0)
                {
                    SelectedGame = Games.FirstOrDefault(g => g.ID == playerHistory.GameID);
                }
            }



        }

        public void WijzigenPlayerHistory()
        {
            if (CurrentPlayerHistory != null)
            {
                PlayerHistoryDataService contactDS =
                new PlayerHistoryDataService();
                contactDS.UpdatePlayerHistory(CurrentPlayerHistory);

                //Refresh
                LeesPlayerHistory();
            }
        }

        public void ToevoegenPlayerHistory()
        {
            PlayerHistoryDataService contactDS = new PlayerHistoryDataService();
            if (CurrentPlayerHistory != null)
            {
                contactDS.InsertPlayerHistory(CurrentPlayerHistory);
            }
            else
            {
                contactDS.InsertPlayerHistory(new PlayerHistory());
            }


            //Refresh
            LeesPlayerHistory();
        }


        public void VerwijderenPlayerHistory()
        {
            if (CurrentPlayerHistory != null)
            {
                PlayerHistoryDataService contactDS =
                    new PlayerHistoryDataService();
                contactDS.DeletePlayerHistory(CurrentPlayerHistory);

                //Refresh
                LeesPlayerHistory();
            }
        }

        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
                NotifyPropertyChanged();
            }
        }

        private Player selectedPlayer { get; set; }
        public Player SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }

            set
            {
                selectedPlayer = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Color> colors;
        public ObservableCollection<Color> Colors
        {
            get
            {
                return colors;
            }

            set
            {
                colors = value;
                NotifyPropertyChanged();
            }
        }

        private Color selectedColor { get; set; }
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }

            set
            {
                selectedColor = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get
            {
                return games;
            }

            set
            {
                games = value;
                NotifyPropertyChanged();
            }
        }

        private Game selectedGame { get; set; }
        public Game SelectedGame
        {
            get
            {
                return selectedGame;
            }

            set
            {
                selectedGame = value;
                NotifyPropertyChanged();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
