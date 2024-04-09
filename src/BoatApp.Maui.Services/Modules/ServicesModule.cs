using BoatApp.Domain.Logging;
using BoatApp.Domain.Mappers;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Logging;
using Mapster;
using MapsterMapper;

namespace BoatApp.Maui.Services.Modules;

public class ServicesModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDebugLogger, DebugLogger>();
        containerRegistry.RegisterSingleton<IAppCenterLogger, AppCenterLogger>();
        containerRegistry.RegisterSingleton<ILogger, Logging.Logger>();
        containerRegistry.RegisterInstance(TypeAdapterConfig.GlobalSettings);
        containerRegistry.RegisterScoped<IMapper, ServiceMapper>();
        containerRegistry.RegisterSingleton<IServiceMapper, Mappers.ServiceMapper>();

        containerRegistry.RegisterSingleton<IUserService, UserService>();
        containerRegistry.RegisterSingleton<IOwnerBoatService, OwnerBoatService>();
        // containerRegistry.RegisterSingleton<IAuthService, AuthService>();
        //containerRegistry.RegisterSingleton<IGeneralApiService, GeneralApiService>();
        //containerRegistry.RegisterSingleton<IAuthService, AuthService>();
        //containerRegistry.RegisterSingleton<IAccountService, AccountService>();
        //containerRegistry.RegisterSingleton<INudgeService, NudgeService>();
    }
}