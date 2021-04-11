using System;

namespace MensErgerJeNiet.Model
{
    class Game : BaseModel
    {
        private int id;
        private int playerHistoryID;
        private DateTime date;
        private bool isActive;
        private PlayerHistory playerHistory;


        public Game() 
        {
            PlayerHistoryID = 1;
            Date = DateTime.Now;
            IsActive = true;
        }

        public Game(int playerHistoryID, DateTime date, bool isActive)
        {
            PlayerHistoryID = playerHistoryID;
            Date = date;
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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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
