namespace MensErgerJeNiet.Model
{
    class Color : BaseModel
    {
        private int id;
        private string name;
        private string code;


        public Color() 
        {
            Name = "New color";
            Code = "#000000";
        }

        public Color(string name, string code)
        {
            Name = name;
            Code = code;
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

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
