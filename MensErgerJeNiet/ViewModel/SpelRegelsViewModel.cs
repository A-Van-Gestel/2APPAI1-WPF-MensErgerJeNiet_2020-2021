using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class SpelRegelsViewModel : BaseViewModel
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

        // ----- Commands -----
        private void HomeView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("HomeView");
        }
    }
}
