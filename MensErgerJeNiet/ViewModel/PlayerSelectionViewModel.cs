using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class PlayerSelectionViewModel : BaseViewModel
    {
        // ----- ICommands -----
        public ICommand AddPlayerCommand { get; set; }
        public ICommand GotoHomeViewCommand { get; set; }
        public ICommand PlayCommand { get; set; }


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

        private Color colorPlayer1;
        public Color ColorPlayer1
        {
            get
            {
                if (colorPlayer1 == null)
                {
                    colorPlayer1 = new Color();
                }
                return colorPlayer1;
            }

            set
            {
                colorPlayer1 = value;
                NotifyPropertyChanged();
            }
        }

        private Color colorPlayer2;
        public Color ColorPlayer2
        {
            get
            {
                if (colorPlayer2 == null)
                {
                    colorPlayer2 = new Color();
                }
                return colorPlayer2;
            }

            set
            {
                colorPlayer2 = value;
                NotifyPropertyChanged();
            }
        }

        private Color colorPlayer3;
        public Color ColorPlayer3
        {
            get
            {
                if (colorPlayer3 == null)
                {
                    colorPlayer3 = new Color();
                }
                return colorPlayer3;
            }

            set
            {
                colorPlayer3 = value;
                NotifyPropertyChanged();
            }
        }

        private Color colorPlayer4;
        public Color ColorPlayer4
        {
            get
            {
                if (colorPlayer4 == null)
                {
                    colorPlayer4 = new Color();
                }
                return colorPlayer4;
            }

            set
            {
                colorPlayer4 = value;
                NotifyPropertyChanged();
            }
        }

        private Player player1;
        public Player Player1
        {
            get
            {
                if (player1 == null)
                {
                    player1 = new Player("");
                }
                return player1;
            }

            set
            {
                player1 = value;
                NotifyPropertyChanged();
            }
        }

        private Player player2;
        public Player Player2
        {
            get
            {
                if (player2 == null)
                {
                    player2 = new Player("");
                }
                return player2;
            }

            set
            {
                player2 = value;
                NotifyPropertyChanged();
            }
        }

        private Player player3;
        public Player Player3
        {
            get
            {
                if (player3 == null)
                {
                    player3 = new Player("");
                }
                return player3;
            }

            set
            {
                player3 = value;
                NotifyPropertyChanged();
            }
        }

        private Player player4;
        public Player Player4
        {
            get
            {
                if (player4 == null)
                {
                    player4 = new Player("");
                }
                return player4;
            }

            set
            {
                player4 = value;
                NotifyPropertyChanged();
            }
        }


        public PlayerSelectionViewModel()
        {
            LeesColors();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
            PlayCommand = new BaseCommand(Play);
            AddPlayerCommand = new BaseCommand(AddPlayer);
    }

        private void LeesColors()
        {
            //instantiëren dataservice
            ColorDataService contactDS =
               new ColorDataService();

            Colors = new ObservableCollection<Color>(contactDS.GetColors());
        }

        public void AddPlayer()
        {
            PlayerDataService contactDS = new PlayerDataService();
            if (Player1 != null)
            {
                contactDS.InsertPlayer(Player1);
            }
            if (Player2 != null)
            {
                contactDS.InsertPlayer(Player2);
            }
            if (Player3 != null)
            {
                contactDS.InsertPlayer(Player3);
            }
            if (Player4 != null)
            {
                contactDS.InsertPlayer(Player4);
            }
        }

        // ----- Commands -----
        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }

        private void Play()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("PlayView");
        }
    }
}
