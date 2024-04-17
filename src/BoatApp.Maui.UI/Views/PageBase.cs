using BoatApp.Maui.UI.Helpers;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace BoatApp.Maui.UI.Views;

public class PageBase : ContentPage
{
    public PageBase()
    {
        BackgroundColor = (Color)ResourceHelpers.FindResource("Background");
        Microsoft.Maui.Controls.NavigationPage.SetHasNavigationBar(this, false);
        Padding = new Thickness(0);
        
        On<iOS>().SetUseSafeArea(false);
    }
}