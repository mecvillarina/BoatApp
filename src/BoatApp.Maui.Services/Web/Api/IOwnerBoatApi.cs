using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using Refit;

namespace BoatApp.Maui.Services.Web.Api;

public interface IOwnerBoatApi
{
    HttpClient Client { get; }
    
    [Post("/action/find")]
    Task<BoatRootContract> GetBoatsByPhoneNumberAsync([Body(true)] GenericRequestContract<GetBoatsByPhoneRequestContract> contract);
}