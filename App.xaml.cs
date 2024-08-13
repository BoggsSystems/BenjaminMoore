using System;
using System.Windows;

namespace ProductSearchApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void OnStartup(object sender, StartupEventArgs e)
    {
        base.OnStartup(e);

        // Show splash screen
        SplashScreen splashScreen = new SplashScreen("Images/Benjamin_Moore_Logo.png");
        splashScreen.Show(autoClose: true, topMost: true);

        // Initialize the main window, but don't show it yet
        MainWindow mainWindow = new MainWindow();

        mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        mainWindow.Visibility = Visibility.Visible;
        mainWindow.WindowState = WindowState.Normal;

        Console.WriteLine("Showing splash screen.");
        Console.WriteLine("Showing main window.");

        // After the splash screen has shown, load the main window
        mainWindow.Show();
    }
}
