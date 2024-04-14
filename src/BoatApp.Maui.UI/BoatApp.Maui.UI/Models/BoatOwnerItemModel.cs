using CommunityToolkit.Mvvm.ComponentModel;

namespace BoatApp.Maui.UI.Models;

public partial class BoatOwnerItemModel : ObservableObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _phoneNumber;
    [ObservableProperty] private string _profilePictureUrl;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(BoatsDisplay))] 
    List<string> _boats = new ();

    public string BoatsDisplay => $"{Boats.Count} listed Boats";
}