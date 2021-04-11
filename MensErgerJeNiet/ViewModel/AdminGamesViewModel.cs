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
            ReadGame();
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
            UpdateCommand = new BaseCommand(UpdateGame);
            DeleteCommand = new BaseCommand(DeleteGame);
            AddCommand = new BaseCommand(AddGame);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void ReadGame()
        {
            //instantiëren dataservice
            GameDataService contactDS =
               new GameDataService();

            Games = new ObservableCollection<Game>(contactDS.GetGames());
        }

        public void UpdateGame()
        {
            if (CurrentGame != null)
            {
                GameDataService contactDS =
                new GameDataService();
                contactDS.UpdateGame(CurrentGame);

                //Refresh
                ReadGame();
            }
        }

        public void AddGame()
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
            ReadGame();
        }


        public void DeleteGame()
        {
            if (CurrentGame != null)
            {
                GameDataService contactDS =
                    new GameDataService();
                contactDS.DeleteGame(CurrentGame);

                //Refresh
                ReadGame();
            }
        }


        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
