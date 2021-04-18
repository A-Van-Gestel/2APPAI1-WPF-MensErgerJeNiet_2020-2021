using System;

namespace MensErgerJeNiet.Model
{
    class Color : BaseModel
    {
        private int id;
        private string name;
        private string code;


        public Color()
        {
            var random = new Random();
            var randomColor = $"#{random.Next(0x1000000):X6}";

            Name = $"New color ({randomColor})";
            Code = randomColor;
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
