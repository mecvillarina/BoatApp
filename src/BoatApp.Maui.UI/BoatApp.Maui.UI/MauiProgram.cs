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

                fonts.AddMaterialIconFonts();
            });

        builder.Services.AddMopupsDialogs();
        return builder.Build();
    }
}