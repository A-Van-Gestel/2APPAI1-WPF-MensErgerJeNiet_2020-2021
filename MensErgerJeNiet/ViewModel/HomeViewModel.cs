using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.ViewModel
{
    class HomeViewModel
    {
        // When Button_Spelregels_Click is pressed
        PageNavigationService pageNavigationService = new PageNavigationService();
        pageNavigationService.Navigate("SpelRegelsView");
    }
}
