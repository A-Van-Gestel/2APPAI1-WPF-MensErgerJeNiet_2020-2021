using MensErgerJeNiet.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminPositionsViewModel : BaseViewModel
    {
        public AdminPositionsViewModel()
        {
            ReadPosition();
            KoppelenCommands();
        }

        private ObservableCollection<Position> positions;
        public ObservableCollection<Position> Positions
        {
            get
            {
                return positions;
            }

            set
            {
                positions = value;
                NotifyPropertyChanged();
            }
        }

        private Position currentPosition;
        public Position CurrentPosition
        {
            get
            {
                if (currentPosition == null)
                {
                    currentPosition = new Position();
                }
                return currentPosition;
            }

            set
            {
                currentPosition = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            UpdateCommand = new BaseCommand(UpdatePosition);
            DeleteCommand = new BaseCommand(DeletePosition);
            AddCommand = new BaseCommand(AddPosition);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void ReadPosition()
        {
            //instantiëren dataservice
            PositionDataService contactDS =
               new PositionDataService();

            Positions = new ObservableCollection<Position>(contactDS.GetPositions());

            //PlayerHistories inlezen
            PlayerHistoryDataService playerHistoryDataService = new PlayerHistoryDataService();
            PlayerHistories = playerHistoryDataService.GetPlayerHistories();

            foreach (Position position in Positions)
            {
                //Relatie
                if (position.PlayerHistoryID > 0)
                {
                    SelectedPlayerHistory = PlayerHistories.FirstOrDefault(ph => ph.ID == position.PlayerHistoryID);
                }
            }

        }

        public void UpdatePosition()
        {
            if (CurrentPosition != null)
            {
                PositionDataService contactDS =
                new PositionDataService();
                contactDS.UpdatePosition(CurrentPosition);

                //Refresh
                ReadPosition();
            }
        }

        public void AddPosition()
        {
            PositionDataService contactDS = new PositionDataService();
            if (CurrentPosition != null)
            {
                contactDS.InsertPosition(CurrentPosition);
            }
            else
            {
                contactDS.InsertPosition(new Position());
            }

            //Refresh
            ReadPosition();
        }


        public void DeletePosition()
        {
            if (CurrentPosition != null)
            {
                PositionDataService contactDS =
                    new PositionDataService();
                contactDS.DeletePosition(CurrentPosition);

                //Refresh
                ReadPosition();
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
