using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using Refit;

namespace BoatApp.Maui.Services.Web.Api;

[Headers("Content-Type: application/json")]
public interface IOwnerApi
{
    HttpClient Client { get; }

    [Post("/action/find")]
    Task<OwnerRootContract> GetOwnerByPhoneAsync([Body(true)] GetOwnerByPhoneRootRequestContract contract);
    
    [Post("/action/find")]
    Task<OwnerRootContract> GetOwnersAsync([Body(true)] GetOwnersRootRequestContract contract);
}