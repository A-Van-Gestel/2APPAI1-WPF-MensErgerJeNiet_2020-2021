using MensErgerJeNiet.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminGamesViewModel : BaseViewModel
    {
        public AdminGamesViewModel()
        {
            LeesGame();
            KoppelenCommands();
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

        private Game currentGame;
        public Game CurrentGame
        {
            get
            {
                if (currentGame == null)
                {
                    currentGame = new Game();
                }
                return currentGame;
            }

            set
            {
                currentGame = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenGame);
            VerwijderenCommand = new BaseCommand(VerwijderenGame);
            ToevoegenCommand = new BaseCommand(ToevoegenGame);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void LeesGame()
        {
            //instantiëren dataservice
            GameDataService contactDS =
               new GameDataService();

            Games = new ObservableCollection<Game>(contactDS.GetGame());

            //PlayerHistories inlezen
            PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
            PlayerHistories = playerHistoryDataService.GetPlayerHistories();

            foreach (Game game in Games)
            {
                //Relatie
                if (game.PlayerHistoryID > 0)
                {
                    SelectedPlayerHistory = PlayerHistories.FirstOrDefault(ph => ph.ID == game.PlayerHistoryID);
                }
            }
        }

        public void WijzigenGame()
        {
            if (CurrentGame != null)
            {
                GameDataService contactDS =
                new GameDataService();
                contactDS.UpdateGame(CurrentGame);

                //Refresh
                LeesGame();
            }
        }

        public void ToevoegenGame()
        {
            GameDataService contactDS = new GameDataService();
            if (CurrentGame != null)
            {
                contactDS.InsertGame(CurrentGame);
            }
            else
            {
                contactDS.InsertGame(new Game());
            }
                
            //Refresh
            LeesGame();
        }


        public void VerwijderenGame()
        {
            if (CurrentGame != null)
            {
                GameDataService contactDS =
                    new GameDataService();
                contactDS.DeleteGame(CurrentGame);

                //Refresh
                LeesGame();
            }
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

        private PlayerHistory selectedPlayerHistory { get; set; }
        public PlayerHistory SelectedPlayerHistory
        {
            get
            {
                return selectedPlayerHistory;
            }

            set
            {
                selectedPlayerHistory = value;
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
