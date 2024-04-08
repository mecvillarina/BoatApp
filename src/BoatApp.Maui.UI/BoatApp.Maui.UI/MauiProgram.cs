using CommunityToolkit.Maui;
using Mopups.Hosting;
using InputKit.Shared.Controls;
using UraniumUI;

namespace BoatApp.Maui.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(PrismStartup.Configure)
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                
                fonts.AddFont("ProstoOne-Regular.ttf", "ProstoOneRegular");
                fonts.AddFont("SF-UI-Display-Regular.ttf", "SFUIDisplayRegular");
                fonts.AddFont("SF-UI-Display-Bold.ttf", "SFUIDisplayBold");
                fonts.AddFont("SF-UI-Display-Medium.ttf", "SFUIDisplayMedium");
                fonts.AddFont("SF-UI-Display-Semibold.ttf", "SFUIDisplaySemibold");

                fonts.AddMaterialIconFonts();
            });

        builder.Services.AddMopupsDialogs();
        return builder.Build();
    }
}