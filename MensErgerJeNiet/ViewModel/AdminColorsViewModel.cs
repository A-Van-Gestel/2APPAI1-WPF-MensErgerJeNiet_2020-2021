using MensErgerJeNiet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminColorsViewModel : BaseViewModel
    {
        public AdminColorsViewModel()
        {
            LeesColors();
            KoppelenCommands();
        }

        private ObservableCollection<Color> colors;
        public ObservableCollection<Color> Colors
        {
            get
            {
                return colors;
            }

            set
            {
                colors = value;
                NotifyPropertyChanged();
            }
        }

        private Color currentColor;
        public Color CurrentColor
        {
            get
            {
                if (currentColor == null)
                {
                    currentColor = new Color();
                }
                return currentColor;
            }

            set
            {
                currentColor = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenColor);
            VerwijderenCommand = new BaseCommand(VerwijderenColor);
            ToevoegenCommand = new BaseCommand(ToevoegenColor);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void LeesColors()
        {
            //instantiëren dataservice
            ColorDataService contactDS =
               new ColorDataService();

            Colors = new ObservableCollection<Color>(contactDS.GetColors());
        }

        public void WijzigenColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                new ColorDataService();
                contactDS.UpdateColor(CurrentColor);

                //Refresh
                LeesColors();
            }
        }

        public void ToevoegenColor()
        {
            ColorDataService contactDS = new ColorDataService();
            if (CurrentColor != null)
            {
                contactDS.InsertColor(CurrentColor);
            }
            else
            {
                contactDS.InsertColor(new Color());
            }

            CurrentColor = new Color();

            //Refresh
            LeesColors();
        }


        public void VerwijderenColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                    new ColorDataService();
                contactDS.DeleteColor(CurrentColor);

                //Refresh
                LeesColors();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
