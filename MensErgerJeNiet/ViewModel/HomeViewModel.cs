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
        public ICommand GotoPlayerSelectionViewCommand { get; set; }
        public ICommand GotoHistoryViewCommand { get; set; }
        public ICommand GotoSpelRegelsViewCommand { get; set; }


        public HomeViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            GotoPlayerSelectionViewCommand = new BaseCommand(PlayerSelectionView);
            GotoHistoryViewCommand = new BaseCommand(HistoryView);
            GotoSpelRegelsViewCommand = new BaseCommand(SpelRegelsView);
        }

        // ----- Commands -----
        private void PlayerSelectionView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("PlayerSelectionView");
        }

        private void HistoryView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HistoryView");
        }

        private void SpelRegelsView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("SpelRegelsView");
        }
    }
}
