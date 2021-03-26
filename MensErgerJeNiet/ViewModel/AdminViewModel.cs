using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class AdminViewModel : BaseViewModel
    {
        // ----- ICommands -----
        public ICommand GotoHomeViewCommand { get; set; }
        public ICommand GotoAdminColorsViewCommand { get; set; }


        public AdminViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
            GotoAdminColorsViewCommand = new BaseCommand(AdminColorsView);
        }

        // ----- Commands -----
        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }

        private void AdminColorsView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminColorsView");
        }
    }
}
