using BoatApp.Maui.Domain.Services;
using CommunityToolkit.Maui.Views;

namespace BoatApp.Maui.UI.Services;

public class PopupService : IPopupService
{
    public async Task ShowAsync<TPopup>(TPopup popup) where TPopup : Popup
    {
        await Application.Current.MainPage.ShowPopupAsync(popup);
    }
}