using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class PlayViewModel : BaseViewModel
    {
        private Board board;
        public Board Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
                NotifyPropertyChanged();
            }
        }


        // ----- ICommands -----
        public ICommand GotoHomeViewCommand { get; set; }


        public PlayViewModel()
        {
            Board = new Board();
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
