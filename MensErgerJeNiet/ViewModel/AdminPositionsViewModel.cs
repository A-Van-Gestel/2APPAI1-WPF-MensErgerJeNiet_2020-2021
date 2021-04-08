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
            LeesPosition();
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
            WijzigenCommand = new BaseCommand(WijzigenPosition);
            VerwijderenCommand = new BaseCommand(VerwijderenPosition);
            ToevoegenCommand = new BaseCommand(ToevoegenPosition);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void LeesPosition()
        {
            //instantiëren dataservice
            PositionDataService contactDS =
               new PositionDataService();

            Positions = new ObservableCollection<Position>(contactDS.GetPosition());

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

        public void WijzigenPosition()
        {
            if (CurrentPosition != null)
            {
                PositionDataService contactDS =
                new PositionDataService();
                contactDS.UpdatePosition(CurrentPosition);

                //Refresh
                LeesPosition();
            }
        }

        public void ToevoegenPosition()
        {
            PositionDataService contactDS = new PositionDataService();
            contactDS.InsertPosition(new Position(playerHistoryID: 1, pion: 1, coordinate: 1, isHome: true, isActive: false));

            //Refresh
            LeesPosition();
        }


        public void VerwijderenPosition()
        {
            if (CurrentPosition != null)
            {
                PositionDataService contactDS =
                    new PositionDataService();
                contactDS.DeletePosition(CurrentPosition);

                //Refresh
                LeesPosition();
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
