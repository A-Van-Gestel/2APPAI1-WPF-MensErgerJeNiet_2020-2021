using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class SpelRegelsViewModel
    {
        // ----- ICommands -----
        public ICommand GotoHomeViewCommand { get; set; }


        public SpelRegelsViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoHomeViewCommand = new BaseCommand(HomeView);
        }

        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }
    }
}
