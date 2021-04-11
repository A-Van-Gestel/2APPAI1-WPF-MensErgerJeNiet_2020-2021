using MensErgerJeNiet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminPlayersViewModel : BaseViewModel
    {
        public AdminPlayersViewModel()
        {
            LeesPlayer();
            KoppelenCommands();
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

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get
            {
                if (currentPlayer == null)
                {
                    currentPlayer = new Player();
                }
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenPlayer);
            VerwijderenCommand = new BaseCommand(VerwijderenPlayer);
            ToevoegenCommand = new BaseCommand(ToevoegenPlayer);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void LeesPlayer()
        {
            //instantiëren dataservice
            PlayerDataService contactDS =
               new PlayerDataService();

            Players = new ObservableCollection<Player>(contactDS.GetPlayers());
        }

        public void WijzigenPlayer()
        {
            if (CurrentPlayer != null)
            {
                PlayerDataService contactDS =
                new PlayerDataService();
                contactDS.UpdatePlayer(CurrentPlayer);

                //Refresh
                LeesPlayer();
            }
        }

        public void ToevoegenPlayer()
        {
            PlayerDataService contactDS = new PlayerDataService();
            if (CurrentPlayer != null)
            {
                contactDS.InsertPlayer(CurrentPlayer);
            }
            else
            {
                contactDS.InsertPlayer(new Player());
            }
            
            //Refresh
            LeesPlayer();
        }


        public void VerwijderenPlayer()
        {
            if (CurrentPlayer != null)
            {
                PlayerDataService contactDS =
                    new PlayerDataService();
                contactDS.DeletePlayer(CurrentPlayer);

                //Refresh
                LeesPlayer();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
