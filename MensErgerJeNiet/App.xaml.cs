using MensErgerJeNiet.Model;
using MensErgerJeNiet.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MensErgerJeNiet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // ----- Splashscreen -----
        private const int SplashTime = 1500; // Miliseconds

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Create new SplashScreen & show it without autoclosing
            SplashScreen splash = new SplashScreen("images/SplashScreen.png");
            splash.Show(false);

            // Create new MainWindow
            MainWindow main = new MainWindow();

            // Sleep to show SplashScreen longer
            Thread.Sleep(SplashTime);

            // Close SplashScreen with a fade
            splash.Close(TimeSpan.FromMilliseconds(300));

            // Show MainWindow
            main.Show();
        }

        // ----- Navigation Service registration-----
        void App_Navigated(object sender, NavigationEventArgs e) 
        {
            Page page = e.Content as Page;
            if (page != null) ApplicationHelper.NavigationService = page.NavigationService;
        }
    }
}
