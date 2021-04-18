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
    class PlayViewModel : BaseViewModel
    {
        public PlayViewModel()
        {
            ReadPlayerHistories();
            ReadPions();
            SetPlayerHistoryPions();
            SetPlayers();
            Board = new Board(Player1.Color.Code, Player2.Color.Code, Player3.Color.Code, Player4.Color.Code, new List<Pion>(pions));
            Dice = new Dice();
            KoppelenCommands();
        }


        // ----- Game setup -----
        // --- Variables ---
        private Board board;
        private PlayerHistory player1;
        private PlayerHistory player2;
        private PlayerHistory player3;
        private PlayerHistory player4;
        private bool isActivePion1 = true;
        private bool isActivePion2 = true;
        private bool isActivePion3 = true;
        private bool isActivePion4 = true;

        public Board Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
                NotifyPropertyChanged();
            }
        }

        public PlayerHistory Player1
        {
            get
            {
                return player1;
            }
            set
            {
                player1 = value;
                NotifyPropertyChanged();
            }
        }

        public PlayerHistory Player2
        {
            get
            {
                return player2;
            }
            set
            {
                player2 = value;
                NotifyPropertyChanged();
            }
        }

        public PlayerHistory Player3
        {
            get
            {
                return player3;
            }
            set
            {
                player3 = value;
                NotifyPropertyChanged();
            }
        }

        public PlayerHistory Player4
        {
            get
            {
                return player4;
            }
            set
            {
                player4 = value;
                NotifyPropertyChanged();
            }
        }


        // --- Functions ---
        private int GameActiveID()
        {
            GameDataService contactDS = new GameDataService();
            ObservableCollection<Game> games = contactDS.GetGames();
            foreach (Game game in games)
            {
                if (game.IsActive == true)
                {
                    return game.ID;
                }
            }
            return 0;
        }


        private List<PlayerHistory> PlayerHistoriesActive(int gameID)
        {
            List<PlayerHistory> PlayerHistoriesActive_internal = new List<PlayerHistory>();
            PlayerHistoryDataService contactDS = new PlayerHistoryDataService();
            ObservableCollection<PlayerHistory> playerHistories = contactDS.GetPlayerHistories();
            foreach (PlayerHistory playerHistory in playerHistories)
            {
                if (playerHistory.GameID == gameID)
                {
                    PlayerHistoriesActive_internal.Add(playerHistory);
                }
            }
            return PlayerHistoriesActive_internal;
        }


        private void ReadPlayerHistories()
        {
            PlayerHistories = new ObservableCollection<PlayerHistory>(PlayerHistoriesActive(GameActiveID()));

            //Players inlezen
            List<Player> PlayersActive_internal = new List<Player>();
            PlayerDataService playerDataService = new PlayerDataService();
            ObservableCollection<Player> players = playerDataService.GetPlayers();
            foreach (PlayerHistory playerHistory in PlayerHistories)
            {
                foreach (Player player in players)
                {
                    if (playerHistory.PlayerID == player.ID)
                    {
                        PlayersActive_internal.Add(player);
                    }
                }
            }
            Players = new ObservableCollection<Player>(PlayersActive_internal);

            //Colors inlezen
            List<Color> ColorsActive_internal = new List<Color>();
            ColorDataService colorDataService = new ColorDataService();
            ObservableCollection<Color> colors = colorDataService.GetColors();
            foreach (PlayerHistory playerHistory in PlayerHistories)
            {
                foreach (Color color in colors)
                {
                    if (playerHistory.ColorID == color.ID)
                    {
                        ColorsActive_internal.Add(color);
                    }
                }
            }
            Colors = new ObservableCollection<Color>(ColorsActive_internal);

            //Games inlezen
            GameDataService gameDataService = new GameDataService();
            Game = gameDataService.GetGameByID(GameActiveID());

            foreach (PlayerHistory playerHistory in PlayerHistories)
            {
                //Relatie Players
                if (playerHistory.PlayerID > 0)
                {
                    playerHistory.Player = Players.FirstOrDefault(pl => pl.ID == playerHistory.PlayerID);
                }

                //Relatie Colors
                if (playerHistory.ColorID > 0)
                {
                    playerHistory.Color = Colors.FirstOrDefault(c => c.ID == playerHistory.ColorID);
                }

                //Relatie Games
                if (playerHistory.GameID > 0)
                {
                    playerHistory.Game = Game;
                }
            }
        }

        private List<Pion> PionsActive(ObservableCollection<PlayerHistory>PlayerHistories)
        {
            List<Pion> PionsActive_internal = new List<Pion>();
            PionDataService contactDS = new PionDataService();
            ObservableCollection<Pion> pions = contactDS.GetPions();
            foreach (Pion pion in pions)
            {
                foreach (PlayerHistory playerHistory in PlayerHistories)
                {
                    if (pion.PlayerHistoryID == playerHistory.ID)
                    {
                        PionsActive_internal.Add(pion);
                    }
                }
            }
            return PionsActive_internal;
        }

        private void ReadPions()
        {
            Pions = new ObservableCollection<Pion>(PionsActive(playerHistories));

            foreach (Pion pion in Pions)
            {
                //Relatie
                if (pion.PlayerHistoryID > 0)
                {
                    pion.PlayerHistory = PlayerHistories.FirstOrDefault(ph => ph.ID == pion.PlayerHistoryID);
                }
            }
        }

        private void SetPlayerHistoryPions()
        {
            foreach (Pion pion in Pions)
            {
                foreach (PlayerHistory playerHistory in PlayerHistories)
                {
                    if (pion.PlayerHistoryID == playerHistory.ID)
                    {
                        if (pion.PionNr == 1)
                        {
                            playerHistory.Pion1 = pion;
                        }
                        if (pion.PionNr == 2)
                        {
                            playerHistory.Pion2 = pion;
                        }
                        if (pion.PionNr == 3)
                        {
                            playerHistory.Pion3 = pion;
                        }
                        if (pion.PionNr == 4)
                        {
                            playerHistory.Pion4 = pion;
                        }
                    }
                }
            }
        }

        private void SetPlayers()
        {
            if (PlayerHistories.Count == 4)
            {
                Player1 = PlayerHistories[0];
                Player2 = PlayerHistories[1];
                Player3 = PlayerHistories[2];
                Player4 = PlayerHistories[3];
            }
        }

        public bool IsActiveTrow
        {
            get
            {
                return !Dice.IsTrown;
            }
        }

        public bool IsActivePion1
        {
            get
            {
                if (Dice.IsTrown & isActivePion1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                isActivePion1 = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsActivePion2
        {
            get
            {
                if (Dice.IsTrown & isActivePion2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                isActivePion2 = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsActivePion3
        {
            get
            {
                if (Dice.IsTrown & isActivePion3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                isActivePion3 = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsActivePion4
        {
            get
            {
                if (Dice.IsTrown & isActivePion4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                isActivePion4 = value;
                NotifyPropertyChanged();
            }
        }


        // ----- ICommands -----
        public ICommand GotoHomeViewCommand { get; set; }
        public ICommand TrowCommand { get; set; }
        public ICommand MovePion1Command { get; set; }
        public ICommand MovePion2Command { get; set; }
        public ICommand MovePion3Command { get; set; }
        public ICommand MovePion4Command { get; set; }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
            TrowCommand = new BaseCommand(Trow);
            MovePion1Command = new BaseCommand(MovePion1);
            MovePion2Command = new BaseCommand(MovePion2);
            MovePion3Command = new BaseCommand(MovePion3);
            MovePion4Command = new BaseCommand(MovePion4);
        }

        // ----- Commands -----
        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }

        private void Trow()
        {
            Dice.Trow();
        }
        

        private void MovePion1()
        {
            return;
        }

        private void MovePion2()
        {
            return;
        }

        private void MovePion3()
        {
            return;
        }

        private void MovePion4()
        {
            return;
        }


        // ----- Foreign keys and stuff -----
        private Dice dice;
        public Dice Dice
        {
            get
            {
                return dice;
            }
            set
            {
                dice = value;
                NotifyPropertyChanged();
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

        private Game game;
        public Game Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
                NotifyPropertyChanged();
            }
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
    }
}
