namespace MensErgerJeNiet.Model
{
    class PlayerHistory : BaseModel
    {
        private int id;
        private int playerID;
        private int colorID;
        private int gameID;
        private int countTime;
        private int countSixes;
        private int countTurns;
        private bool isTurn;
        private bool isWinner;
        private Player player;
        private Color color;
        private Game game;


        public PlayerHistory() 
        {
            PlayerID = 1;
            ColorID = 1;
            GameID = 1;
            CountTime = 0;
            CountSixes = 0;
            CountTurns = 0;
            IsTurn = false;
            IsWinner = false;
        }

        public PlayerHistory(int playerID, int colorID, int gameID, int countTime, int countSixes, int countTurns, bool isTurn, bool isWinner)
        {
            PlayerID = playerID;
            ColorID = colorID;
            GameID = gameID;
            CountTime = countTime;
            CountSixes = countSixes;
            CountTurns = countTurns;
            IsTurn = isTurn;
            IsWinner = isWinner;
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
                playerID = value.ID;
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
                colorID = value.ID;
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
                gameID = value.ID;
                NotifyPropertyChanged();
            }
        }

        public int CountTime
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
