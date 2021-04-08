namespace MensErgerJeNiet.Model
{
    class PlayerHistory : BaseModel
    {
        private int id;
        private int playerID;
        private int colorID;
        private int countTime;
        private int countSixes;
        private int countTurns;
        private bool isTurn;
        private Player player;
        private Color color;


        public PlayerHistory() { }

        public PlayerHistory(int playerID, int colorID, int countTime, int countSixes, int countTurns, bool isTurn)
        {
            PlayerID = playerID;
            ColorID = colorID;
            CountTime = countTime;
            CountSixes = countSixes;
            CountTurns = countTurns;
            IsTurn = isTurn;
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

        public override string ToString()
        {
            return ID.ToString();
        }

    }
}
