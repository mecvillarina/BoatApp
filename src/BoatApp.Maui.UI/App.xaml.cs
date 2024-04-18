namespace BoatApp.Maui.UI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        VersionTracking.Track();
    }
}