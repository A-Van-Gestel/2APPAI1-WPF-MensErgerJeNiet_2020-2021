using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class PlayerSelectionViewModel : BaseViewModel
    {
        // ----- ICommands -----
        public ICommand AddPlayerCommand { get; set; }
        public ICommand GotoHomeViewCommand { get; set; }
        public ICommand PlayCommand { get; set; }


        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                if (errorMessage == null)
                {
                    errorMessage = "";
                }
                return errorMessage;
            }

            set
            {
                errorMessage = value;
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
            ReadColors();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
            PlayCommand = new BaseCommand(Play);
        }

        private void ReadColors()
        {
            //instantiëren dataservice
            ColorDataService contactDS = new ColorDataService();

            Colors = new ObservableCollection<Color>(contactDS.GetColors());
        }

        // ----- Game Creation -----
        private int player1ID;
        private int player2ID;
        private int player3ID;
        private int player4ID;
        private int gameID;
        private int playerHistory1ID;
        private int playerHistory2ID;
        private int playerHistory3ID;
        private int playerHistory4ID;

        private void AddPlayers()
        {
            PlayerDataService contactDS = new PlayerDataService();
            if (Player1 != null)
            {
                player1ID = contactDS.InsertPlayer(Player1);
            }
            if (Player2 != null)
            {
                player2ID = contactDS.InsertPlayer(Player2);
            }
            if (Player3 != null)
            {
                player3ID = contactDS.InsertPlayer(Player3);
            }
            if (Player4 != null)
            {
                player4ID = contactDS.InsertPlayer(Player4);
            }
        }


        private void AddGame()
        {
            GameDataService contactDS = new GameDataService();

            gameID = contactDS.InsertGame(new Game());
        }


        private void AddPlayerHistories()
        {
            if (gameID != 0)
            {
                PlayerHistoryDataService contactDS = new PlayerHistoryDataService();
                // Player 1
                if (player1ID != 0)
                {
                    playerHistory1ID = contactDS.InsertPlayerHistory(new PlayerHistory(playerID: player1ID,
                                                colorID: ColorPlayer1.ID,
                                                gameID: gameID,
                                                countTime: new TimeSpan(),
                                                countSixes: 0,
                                                countTurns: 0,
                                                isTurn: true,
                                                isWinner: false,
                                                pionOffset: 0));
                }

                // Player 2
                if (player2ID != 0)
                {
                    playerHistory2ID = contactDS.InsertPlayerHistory(new PlayerHistory(playerID: player2ID,
                                                colorID: ColorPlayer2.ID,
                                                gameID: gameID,
                                                countTime: new TimeSpan(),
                                                countSixes: 0,
                                                countTurns: 0,
                                                isTurn: false,
                                                isWinner: false,
                                                pionOffset: 10));
                }
                // Player 3
                if (player3ID != 0)
                {
                    playerHistory3ID = contactDS.InsertPlayerHistory(new PlayerHistory(playerID: player3ID,
                                                colorID: ColorPlayer3.ID,
                                                gameID: gameID,
                                                countTime: new TimeSpan(),
                                                countSixes: 0,
                                                countTurns: 0,
                                                isTurn: false,
                                                isWinner: false,
                                                pionOffset: 20));
                }
                // Player 4
                if (player4ID != 0)
                {
                    playerHistory4ID = contactDS.InsertPlayerHistory(new PlayerHistory(playerID: player4ID,
                                                colorID: ColorPlayer4.ID,
                                                gameID: gameID,
                                                countTime: new TimeSpan(),
                                                countSixes: 0,
                                                countTurns: 0,
                                                isTurn: false,
                                                isWinner: false,
                                                pionOffset: 30));
                }
            }
        }


        private void AddPions()
        {
            PionDataService contactDS = new PionDataService();

            if (playerHistory1ID != 0 & playerHistory2ID != 0 & playerHistory3ID != 0 & playerHistory4ID != 0)
            {
                List<int> playerHistoryIDs = new List<int>() { playerHistory1ID, playerHistory2ID, playerHistory3ID, playerHistory4ID };

                foreach (var playerHistoryID in playerHistoryIDs)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        contactDS.InsertPion(new Pion(playerHistoryID: playerHistoryID,
                                                   pionNr: i,
                                                   coordinate: 1,
                                                   isHome: false,
                                                   isActive: false));
                    }
                }
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
            if (Player1.Name != "" & Player2.Name != "" & Player3.Name != "" & Player4.Name != "")
            {
                if (Player1.Name != Player2.Name &&
                    Player1.Name != Player3.Name &&
                    Player1.Name != Player4.Name &&
                    Player2.Name != Player3.Name &&
                    Player2.Name != Player4.Name &&
                    Player3.Name != Player4.Name)
                {

                    if (ColorPlayer1.ID != 0 & ColorPlayer2.ID != 0 & ColorPlayer3.ID != 0 & ColorPlayer4.ID != 0)
                    {
                        if (ColorPlayer1.ID != ColorPlayer2.ID &&
                            ColorPlayer1.ID != ColorPlayer3.ID &&
                            ColorPlayer1.ID != ColorPlayer4.ID &&
                            ColorPlayer2.ID != ColorPlayer3.ID &&
                            ColorPlayer2.ID != ColorPlayer4.ID &&
                            ColorPlayer3.ID != ColorPlayer4.ID)
                        {
                            ErrorMessage = "";
                            AddPlayers();
                            AddGame();
                            AddPlayerHistories();
                            AddPions();

                            PageNavigationService pageNavigationService = new PageNavigationService();
                            pageNavigationService.Navigate("PlayView");
                        }
                        else
                        {
                            ErrorMessage = "All players need have a different color!";
                        }
                    }
                    else
                    {
                        ErrorMessage = "All players need to pick a color!";
                    }
                }
                else
                {
                    ErrorMessage = "All players need have a different name!";
                }
            }
            else
            {
                ErrorMessage = "All players need to have a name!";
            }
        }
    }
}
