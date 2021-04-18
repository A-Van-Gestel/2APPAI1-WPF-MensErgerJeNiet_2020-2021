using MensErgerJeNiet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminPlayersViewModel : BaseViewModel
    {
        public AdminPlayersViewModel()
        {
            ReadPlayer();
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
            UpdateCommand = new BaseCommand(UpdatePlayer);
            DeleteCommand = new BaseCommand(DeletePlayer);
            AddCommand = new BaseCommand(AddPlayer);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void ReadPlayer()
        {
            //instantiëren dataservice
            PlayerDataService contactDS = new PlayerDataService();

            Players = new ObservableCollection<Player>(contactDS.GetPlayers());
        }

        public void UpdatePlayer()
        {
            if (CurrentPlayer != null)
            {
                PlayerDataService contactDS = new PlayerDataService();
                contactDS.UpdatePlayer(CurrentPlayer);

                //Refresh
                ReadPlayer();
            }
        }

        public void AddPlayer()
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
            ReadPlayer();
        }


        public void DeletePlayer()
        {
            if (CurrentPlayer != null)
            {
                PlayerDataService contactDS = new PlayerDataService();
                contactDS.DeletePlayer(CurrentPlayer);

                //Refresh
                ReadPlayer();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
