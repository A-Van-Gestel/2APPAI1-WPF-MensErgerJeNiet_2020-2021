using System;

namespace MensErgerJeNiet.Model
{
    class Game : BaseModel
    {
        private int id;
        private DateTime date;
        private bool isActive;


        public Game()
        {
            Date = DateTime.Now;
            IsActive = true;
        }

        public Game(DateTime date, bool isActive)
        {
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
            return ID.ToString() + " (" + Date.Year + "-" + Date.Month + "-" + Date.Day + " | " + IsActive + ")";
        }

    }
}
