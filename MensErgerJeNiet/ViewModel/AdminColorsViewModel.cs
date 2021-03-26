﻿using MensErgerJeNiet.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminColorsViewModel : BaseViewModel
    {
        public AdminColorsViewModel()
        {
            LeesColor();
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

        private void LeesColor()
        {
            //instantiëren dataservice
            ColorDataService contactDS =
               new ColorDataService();

            Colors = new ObservableCollection<Color>(contactDS.GetColor());
        }

        public void WijzigenColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                new ColorDataService();
                contactDS.UpdateColor(CurrentColor);

                //Refresh
                LeesColor();
            }
        }

        public void ToevoegenColor()
        {
            ColorDataService contactDS = new ColorDataService();
            contactDS.InsertColor(new Color("New Color", "#000000"));

            //Refresh
            LeesColor();
        }


        public void VerwijderenColor()
        {
            if (CurrentColor != null)
            {
                ColorDataService contactDS =
                    new ColorDataService();
                contactDS.DeleteColor(CurrentColor);

                //Refresh
                LeesColor();
            }
        }

        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
