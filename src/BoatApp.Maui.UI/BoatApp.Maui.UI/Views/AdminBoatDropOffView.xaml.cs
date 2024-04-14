using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Maui.UI.Views;

public partial class AdminBoatDropOffView : ContentView
{
    public AdminBoatDropOffView()
    {
        InitializeComponent();
        
        var mainDisplayInfo = DeviceDisplay.Current.MainDisplayInfo;
        var width = (mainDisplayInfo.Width / mainDisplayInfo.Density);
        var height = (mainDisplayInfo.Height / mainDisplayInfo.Density);

        HeightRequest = height;
        WidthRequest = width;
    }
}