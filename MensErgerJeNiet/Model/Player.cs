namespace MensErgerJeNiet.Model
{
    class Player : BaseModel
    {
        private int id;
        private string name;


        public Player()
        {
            Name = "New player";
        }

        public Player(string name)
        {
            Name = name;
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
