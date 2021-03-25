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
        public ICommand GotoPlayerSelectionViewCommand { get; set; }


        public HomeViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoSpelRegelsViewCommand = new BaseCommand(SpelRegelsView);
            GotoPlayerSelectionViewCommand = new BaseCommand(PlayerSelectionView);
        }

        // ----- Commands -----
        private void SpelRegelsView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("SpelRegelsView");
        }

        private void PlayerSelectionView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("PlayerSelectionView");
        }
    }
}
