namespace MensErgerJeNiet.Model
{
    class Position : BaseModel
    {
        private int id;
        private int playerHistoryID;
        private int pion;
        private int coordinate;
        private bool isHome;
        private bool isActive;
        private PlayerHistory playerHistory;


        public Position() { }

        public Position(int playerHistoryID, int pion, int coordinate, bool isHome, bool isActive)
        {
            PlayerHistoryID = playerHistoryID;
            Pion = pion;
            Coordinate = coordinate;
            IsHome = isHome;
            IsActive = isActive;
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

        public int PlayerHistoryID
        {
            get
            {
                return playerHistoryID;
            }

            set
            {
                playerHistoryID = value;
                NotifyPropertyChanged();
            }
        }

        public PlayerHistory PlayerHistory
        {
            get { return playerHistory; }
            set
            {
                playerHistory = value;
                playerHistoryID = value.ID;
                NotifyPropertyChanged();
            }
        }

        public int Pion
        {
            get
            {
                return pion;
            }

            set
            {
                pion = value;
                NotifyPropertyChanged();
            }
        }

        public int Coordinate
        {
            get
            {
                return coordinate;
            }

            set
            {
                coordinate = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsHome
        {
            get
            {
                return isHome;
            }

            set
            {
                isHome = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return ID.ToString();
        }

    }
}
