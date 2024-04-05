using BoatApp.Maui.UI.Helpers;

namespace BoatApp.Maui.UI.Views;

public class PageBase : ContentPage
{
    public PageBase()
    {
        BackgroundColor = (Color)ResourceHelpers.FindResource("Background");
        NavigationPage.SetHasNavigationBar(this, false);
    }
}