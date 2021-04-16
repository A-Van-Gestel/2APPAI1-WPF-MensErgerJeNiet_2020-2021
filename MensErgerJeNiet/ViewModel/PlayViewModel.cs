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
            Board = new Board();
            ReadPlayerHistories();
            ReadPositions();
            KoppelenCommands();
        }


        // ----- Game setup -----
        private Board board;
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

        private List<Position> PositionsActive(ObservableCollection<PlayerHistory>PlayerHistories)
        {
            List<Position> PositionsActive_internal = new List<Position>();
            PositionDataService contactDS = new PositionDataService();
            ObservableCollection<Position> positions = contactDS.GetPositions();
            foreach (Position position in positions)
            {
                foreach (PlayerHistory playerHistory in PlayerHistories)
                {
                    if (position.PlayerHistoryID == playerHistory.ID)
                    {
                        PositionsActive_internal.Add(position);
                    }
                }
            }
            return PositionsActive_internal;
        }

        private void ReadPositions()
        {
            Positions = new ObservableCollection<Position>(PositionsActive(playerHistories));

            foreach (Position position in Positions)
            {
                //Relatie
                if (position.PlayerHistoryID > 0)
                {
                    position.PlayerHistory = PlayerHistories.FirstOrDefault(ph => ph.ID == position.PlayerHistoryID);
                }
            }
        }


        // ----- ICommands -----
        public ICommand GotoHomeViewCommand { get; set; }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
        }

        // ----- Commands -----
        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }


        // ----- Foreign keys and stuff -----
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
    }
}
