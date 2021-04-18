namespace MensErgerJeNiet.Model
{
    class Pion : BaseModel
    {
        private int id;
        private int playerHistoryID;
        private int pionNr;
        private int coordinate;
        private bool isHome;
        private bool isActive;
        private PlayerHistory playerHistory;


        public Pion()
        {
            PlayerHistoryID = 1;
            PionNr = 1;
            Coordinate = 1;
            IsHome = true;
            IsActive = false;
        }

        public Pion(int playerHistoryID, int pionNr, int coordinate, bool isHome, bool isActive)
        {
            PlayerHistoryID = playerHistoryID;
            PionNr = pionNr;
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
                if (playerHistory != null)
                {
                    playerHistoryID = value.ID;
                }

                NotifyPropertyChanged();
            }
        }

        public int PionNr
        {
            get
            {
                return pionNr;
            }

            set
            {
                pionNr = value;
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
