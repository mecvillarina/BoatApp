using CommunityToolkit.Maui.Views;

namespace BoatApp.Maui.Domain.Services;

public interface IPopupService
{
    Task ShowAsync<TPopup>(TPopup popup) where TPopup : Popup;
}