using BoatApp.Maui.UI.Helpers;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace BoatApp.Maui.UI.Views;

public class PageBase : ContentPage
{
    public PageBase()
    {
        BackgroundColor = (Color)ResourceHelpers.FindResource("Background");
        Microsoft.Maui.Controls.NavigationPage.SetHasNavigationBar(this, false);
        
        On<iOS>().SetUseSafeArea(false);
        
        this.Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = (Color)ResourceHelpers.FindResource("Primary"),
            StatusBarStyle = StatusBarStyle.LightContent
        });
    }
}