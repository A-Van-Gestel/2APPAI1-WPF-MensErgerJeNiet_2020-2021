using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MensErgerJeNiet.ViewModel
{
    class HomeViewModel : BaseViewModel
    {
        // ----- ICommands -----
        public ICommand PlayCommand { get; set; }
        public ICommand GotoHistoryViewCommand { get; set; }
        public ICommand GotoSpelRegelsViewCommand { get; set; }
        public ICommand GotoAdminViewCommand { get; set; }


        public HomeViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            PlayCommand = new BaseCommand(Play);
            GotoHistoryViewCommand = new BaseCommand(HistoryView);
            GotoSpelRegelsViewCommand = new BaseCommand(SpelRegelsView);
            GotoAdminViewCommand = new BaseCommand(AdminView);
        }


        private bool IsGameActive()
        {
            GameDataService contactDS = new GameDataService();
            ObservableCollection<Game> games = contactDS.GetGames();
            foreach (Game game in games)
            {
                if (game.IsActive == true)
                {
                    return true;
                }
            }
            return false;
        }



        // ----- Commands -----
        private void Play()
        {
            if (IsGameActive())
            {
                PlayView();
            }
            else
            {
                PlayerSelectionView();
            }
        }

        private void PlayerSelectionView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("PlayerSelectionView");
        }

        private void PlayView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("PlayView");
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
        
        private void AdminView()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("AdminView");
        }
    }
}
