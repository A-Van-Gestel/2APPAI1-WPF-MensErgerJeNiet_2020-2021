using MensErgerJeNiet.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminPionsViewModel : BaseViewModel
    {
        public AdminPionsViewModel()
        {
            ReadPion();
            KoppelenCommands();
        }

        private ObservableCollection<Pion> pions;
        public ObservableCollection<Pion> Pions
        {
            get
            {
                return pions;
            }

            set
            {
                pions = value;
                NotifyPropertyChanged();
            }
        }

        private Pion currentPion;
        public Pion CurrentPion
        {
            get
            {
                if (currentPion == null)
                {
                    currentPion = new Pion();
                }
                return currentPion;
            }

            set
            {
                currentPion = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            UpdateCommand = new BaseCommand(UpdatePion);
            DeleteCommand = new BaseCommand(DeletePion);
            AddCommand = new BaseCommand(AddPion);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void ReadPion()
        {
            //instantiëren dataservice
            PionDataService contactDS = new PionDataService();

            Pions = new ObservableCollection<Pion>(contactDS.GetPions());

            //PlayerHistories inlezen
            PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
            PlayerHistories = playerHistoryDataService.GetPlayerHistories();

            foreach (Pion pion in Pions)
            {
                //Relatie
                if (pion.PlayerHistoryID > 0)
                {
                    SelectedPlayerHistory = PlayerHistories.FirstOrDefault(ph => ph.ID == pion.PlayerHistoryID);
                }
            }
        }

        public void UpdatePion()
        {
            if (CurrentPion != null)
            {
                PionDataService contactDS = new PionDataService();
                contactDS.UpdatePion(CurrentPion);

                //Refresh
                ReadPion();
            }
        }

        public void AddPion()
        {
            PionDataService contactDS = new PionDataService();
            if (CurrentPion != null)
            {
                contactDS.InsertPion(CurrentPion);
            }
            else
            {
                contactDS.InsertPion(new Pion());
            }

            //Refresh
            ReadPion();
        }


        public void DeletePion()
        {
            if (CurrentPion != null)
            {
                PionDataService contactDS = new PionDataService();
                contactDS.DeletePion(CurrentPion);

                //Refresh
                ReadPion();
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
