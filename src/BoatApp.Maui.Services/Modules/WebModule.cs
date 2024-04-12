using System.Net.Http.Headers;
using BoatApp.Common.Constants;
using BoatApp.Maui.Services.Web.Api;
using Refit;

namespace BoatApp.Maui.Services.Modules;

public class WebModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance(CreateRestService<IOwnerApi>(Server.ApiUrl));
        containerRegistry.RegisterInstance(CreateRestService<IOwnerBoatApi>(Server.ApiUrl));
        containerRegistry.RegisterInstance(CreateRestService<IAdminBoatRequestApi>(Server.ApiUrl));
    }

    private T CreateRestService<T>(string apiAddress)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(apiAddress),
            Timeout = TimeSpan.FromSeconds(30)
        };

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("api-key",Server.ApiKey);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return RestService.For<T>(httpClient);
    }
}
