using System;

namespace MensErgerJeNiet.Model
{
    class PlayerHistory : BaseModel
    {
        private int id;
        private int playerID;
        private int colorID;
        private int gameID;
        private TimeSpan countTime;
        private int countSixes;
        private int countTurns;
        private bool isTurn;
        private bool isWinner;
        private int pionOffset;
        private Player player;
        private Color color;
        private Game game;
        private Pion pion1;
        private Pion pion2;
        private Pion pion3;
        private Pion pion4;


        public PlayerHistory()
        {
            PlayerID = 1;
            ColorID = 1;
            GameID = 1;
            CountTime = TimeSpan.FromSeconds(0);
            CountSixes = 0;
            CountTurns = 0;
            IsTurn = false;
            IsWinner = false;
            PionOffset = 0;
        }

        public PlayerHistory(int playerID, int colorID, int gameID, TimeSpan countTime, int countSixes, int countTurns, bool isTurn, bool isWinner, int pionOffset)
        {
            PlayerID = playerID;
            ColorID = colorID;
            GameID = gameID;
            CountTime = countTime;
            CountSixes = countSixes;
            CountTurns = countTurns;
            IsTurn = isTurn;
            IsWinner = isWinner;
            PionOffset = pionOffset;
        }


        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int PlayerID
        {
            get
            {
                return playerID;
            }

            set
            {
                playerID = value;
                NotifyPropertyChanged();
            }
        }

        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
                if (player != null)
                {
                    playerID = value.ID;
                }
                NotifyPropertyChanged();
            }
        }

        public int ColorID
        {
            get
            {
                return colorID;
            }

            set
            {
                colorID = value;
                NotifyPropertyChanged();
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                if (color != null)
                {
                    colorID = value.ID;
                }
                NotifyPropertyChanged();
            }
        }

        public int GameID
        {
            get
            {
                return gameID;
            }

            set
            {
                gameID = value;
                NotifyPropertyChanged();
            }
        }

        public Game Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
                if (game != null)
                {
                    gameID = value.ID;
                }
                NotifyPropertyChanged();
            }
        }

        public TimeSpan CountTime
        {
            get
            {
                return countTime;
            }

            set
            {
                countTime = value;
                NotifyPropertyChanged();
            }
        }

        public int CountSixes
        {
            get
            {
                return countSixes;
            }

            set
            {
                countSixes = value;
                NotifyPropertyChanged();
            }
        }

        public int CountTurns
        {
            get
            {
                return countTurns;
            }

            set
            {
                countTurns = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsTurn
        {
            get
            {
                return isTurn;
            }

            set
            {
                isTurn = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsWinner
        {
            get
            {
                return isWinner;
            }

            set
            {
                isWinner = value;
                NotifyPropertyChanged();
            }
        }

        public int PionOffset
        {
            get
            {
                return pionOffset;
            }

            set
            {
                pionOffset = value;
                NotifyPropertyChanged();
            }
        }

        public Pion Pion1
        {
            get
            {
                return pion1;
            }

            set
            {
                pion1 = value;
                NotifyPropertyChanged();
            }
        }

        public Pion Pion2
        {
            get
            {
                return pion2;
            }

            set
            {
                pion2 = value;
                NotifyPropertyChanged();
            }
        }

        public Pion Pion3
        {
            get
            {
                return pion3;
            }

            set
            {
                pion3 = value;
                NotifyPropertyChanged();
            }
        }

        public Pion Pion4
        {
            get
            {
                return pion4;
            }

            set
            {
                pion4 = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            if (Player != null & Color != null)
            {
                return ID.ToString() + " ( Player: " + Player.Name + " | Color: " + Color.Name + ")";
            }
            else
            {
                return ID.ToString();
            }
        }

    }
}
