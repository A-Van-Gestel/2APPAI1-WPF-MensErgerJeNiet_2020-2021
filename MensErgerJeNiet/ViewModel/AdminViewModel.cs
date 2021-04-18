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
        public ICommand GotoAdminGamesViewCommand { get; set; }
        public ICommand GotoAdminPlayersViewCommand { get; set; }
        public ICommand GotoAdminPionsViewCommand { get; set; }
        public ICommand GotoAdminPlayerHistoriesViewCommand { get; set; }


        public AdminViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
            GotoAdminColorsViewCommand = new BaseCommand(AdminColorsView);
            GotoAdminGamesViewCommand = new BaseCommand(AdminGamesView);
            GotoAdminPlayersViewCommand = new BaseCommand(AdminPlayersView);
            GotoAdminPionsViewCommand = new BaseCommand(AdminPionsView);
            GotoAdminPlayerHistoriesViewCommand = new BaseCommand(AdminPlayerHistoriesView);
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

        private void AdminGamesView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminGamesView");
        }

        private void AdminPlayersView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminPlayersView");
        }

        private void AdminPionsView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminPionsView");
        }

        private void AdminPlayerHistoriesView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminPlayerHistoriesView");
        }
    }
}
