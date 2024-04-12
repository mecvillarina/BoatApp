using Refit;

namespace BoatApp.Maui.Services.Web.Api;

[Headers("Content-Type: application/json")]
public interface IAdminBoatRequestApi
{
    HttpClient Client { get; }
    
    
}