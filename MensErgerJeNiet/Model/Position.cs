namespace MensErgerJeNiet.Model
{
    class Position : BaseModel
    {
        private int id;
        private int playerHistoryID;
        private string pion;
        private string coordinate;
        private bool isHome;
        private bool isActive;


        public Position() { }

        public Position(int playerHistoryID, string pion, string coordinate, bool isHome, bool isActive)
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

        public string Pion
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

        public string Coordinate
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

    }
}
