using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using Refit;

namespace BoatApp.Maui.Services.Web.Api;

public interface IOwnerApi
{
    HttpClient Client { get; }

    [Post("/action/find")]
    Task<OwnerRootContract> GetOwnerByPhoneAsync([Body(true)] GenericRequestContract<GetOwnerByPhoneRequestContract> contract);
}