using CommunityToolkit.Maui.Views;

namespace BoatApp.Maui.UI.Views;

public partial class DropRequestConfirmedPopup : Popup
{
    public DropRequestConfirmedPopup()
    {
        InitializeComponent();
        
        var mainDisplayInfo = DeviceDisplay.Current.MainDisplayInfo;
        var width = (mainDisplayInfo.Width / mainDisplayInfo.Density) - (DeviceInfo.Idiom == DeviceIdiom.Tablet ? 128 : 32);

        MainGrid.ColumnDefinitions = new ColumnDefinitionCollection()
        {
            new ColumnDefinition(width)
        };
        
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(3000);
            await CloseAsync();
        });
    }
    
   
}