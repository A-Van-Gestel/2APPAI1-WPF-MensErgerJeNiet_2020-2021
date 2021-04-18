using MensErgerJeNiet.Model;
using MensErgerJeNiet.View;

namespace MensErgerJeNiet
{
    public class PageNavigationService
    {
        HomeView homePage = null;
        SpelRegelsView spelRegelsPage = null;
        PlayerSelectionView PlayerSelectionPage = null;
        PlayView PlayPage = null;
        HistoryView HistoryPage = null;
        // --- Admin Tools ---
        AdminView AdminPage = null;
        AdminColorsView AdminColorsPage = null;
        AdminGamesView AdminGamesPage = null;
        AdminPlayersView AdminPlayersPage = null;
        AdminPionsView AdminPionsPage = null;
        AdminPlayerHistoriesView AdminPlayerHistoriesPage = null;

        public PageNavigationService()
        {

        }

        public void Navigate(string page)
        {
            switch (page)
            {
                case "HomeView":
                    homePage = new HomeView();
                    ApplicationHelper.NavigationService.Navigate(homePage);
                    break;
                case "SpelRegelsView":
                    spelRegelsPage = new SpelRegelsView();
                    ApplicationHelper.NavigationService.Navigate(spelRegelsPage);
                    break;
                case "PlayerSelectionView":
                    PlayerSelectionPage = new PlayerSelectionView();
                    ApplicationHelper.NavigationService.Navigate(PlayerSelectionPage);
                    break;
                case "PlayView":
                    PlayPage = new PlayView();
                    ApplicationHelper.NavigationService.Navigate(PlayPage);
                    break;
                case "HistoryView":
                    HistoryPage = new HistoryView();
                    ApplicationHelper.NavigationService.Navigate(HistoryPage);
                    break;
                // --- Admin Tools ---
                case "AdminView":
                    AdminPage = new AdminView();
                    ApplicationHelper.NavigationService.Navigate(AdminPage);
                    break;
                case "AdminColorsView":
                    AdminColorsPage = new AdminColorsView();
                    ApplicationHelper.NavigationService.Navigate(AdminColorsPage);
                    break;
                case "AdminGamesView":
                    AdminGamesPage = new AdminGamesView();
                    ApplicationHelper.NavigationService.Navigate(AdminGamesPage);
                    break;
                case "AdminPlayersView":
                    AdminPlayersPage = new AdminPlayersView();
                    ApplicationHelper.NavigationService.Navigate(AdminPlayersPage);
                    break;
                case "AdminPionsView":
                    AdminPionsPage = new AdminPionsView();
                    ApplicationHelper.NavigationService.Navigate(AdminPionsPage);
                    break;
                case "AdminPlayerHistoriesView":
                    AdminPlayerHistoriesPage = new AdminPlayerHistoriesView();
                    ApplicationHelper.NavigationService.Navigate(AdminPlayerHistoriesPage);
                    break;
                default:
                    break;
            }
        }
    }
}
