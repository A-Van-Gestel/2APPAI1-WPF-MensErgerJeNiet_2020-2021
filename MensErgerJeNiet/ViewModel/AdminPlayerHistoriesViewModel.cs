using MensErgerJeNiet.Model;
using System;
using System.Collections.ObjectModel;
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
            contactDS.InsertPlayerHistory(new PlayerHistory(playerID: 1, colorID: 1, countTime: 0, countSixes: 0, countTurns: 0, isTurn: false));

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

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
