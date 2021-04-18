using System.Windows.Navigation;

namespace MensErgerJeNiet.Model
{
    public static class ApplicationHelper
    {
        private static NavigationService navigator;
        public static NavigationService NavigationService
        {
            set
            {
                navigator = value;
            }
            get
            {
                return navigator;
            }
        }
    }
}
