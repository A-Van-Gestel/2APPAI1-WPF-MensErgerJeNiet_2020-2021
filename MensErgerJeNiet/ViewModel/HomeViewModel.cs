using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class HomeViewModel : BaseViewModel
    {
        // ----- ICommands -----
        public ICommand GotoSpelRegelsViewCommand { get; set; }


        public HomeViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoSpelRegelsViewCommand = new BaseCommand(SpelRegelsView);
        }

        private void SpelRegelsView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("SpelRegelsView");
        }
    }
}
