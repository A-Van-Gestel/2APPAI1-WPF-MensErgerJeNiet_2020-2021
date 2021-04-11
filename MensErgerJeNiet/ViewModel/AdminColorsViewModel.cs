using MensErgerJeNiet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminColorsViewModel : BaseViewModel
    {
        public AdminColorsViewModel()
        {
            ReadColors();
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
            UpdateCommand = new BaseCommand(UpdateColor);
            DeleteCommand = new BaseCommand(DeleteColor);
            AddCommand = new BaseCommand(AddColor);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }

        private void ReadColors()
        {
            //instantiëren dataservice
            ColorDataService contactDS =
               new ColorDataService();

            Colors = new ObservableCollection<Color>(contactDS.GetColors());
        }

        public void UpdateColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                new ColorDataService();
                contactDS.UpdateColor(CurrentColor);

                //Refresh
                ReadColors();
            }
        }

        public void AddColor()
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
            ReadColors();
        }


        public void DeleteColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                    new ColorDataService();
                contactDS.DeleteColor(CurrentColor);

                //Refresh
                ReadColors();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
