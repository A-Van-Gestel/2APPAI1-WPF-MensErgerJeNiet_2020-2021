using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.Model
{
    class Dice : BaseModel
    {
        Random random = new Random();

        private int numberDots;
        private bool isTrown;

        public int NumberDots
        {
            get { return numberDots; }
        }

        public bool IsTrown
        {
            get
            {
                return isTrown;
            }

            set
            {
                isTrown = value;
                NotifyPropertyChanged();
            }
        }

        public string Image
        {
            get
            {
                return "/Resources/Images/Dice/" + numberDots + ".png";
            }
        }

        public void Trow()
        {
            numberDots = random.Next(1, 7);
            isTrown = true;
            NotifyPropertyChanged("NumberDots");
            NotifyPropertyChanged("Image");
        }

        public Dice()
        {
            numberDots = 1;
            isTrown = false;
        }

    }
}
