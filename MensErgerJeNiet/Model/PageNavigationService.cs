using MensErgerJeNiet.Model;
using MensErgerJeNiet.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class PageNavigationService
    {
        HomeView homePage = null;
        SpelRegelsView spelRegelsPage = null;
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
                default:
                    break;
            }
        }
    }
}
