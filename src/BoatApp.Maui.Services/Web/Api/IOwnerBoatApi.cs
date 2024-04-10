using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using Refit;

namespace BoatApp.Maui.Services.Web.Api;

[Headers("Content-Type: application/json")]
public interface IOwnerBoatApi
{
    HttpClient Client { get; }
    
    [Post("/action/find")]
    Task<BoatRootContract> GetBoatsByPhoneNumberAsync([Body(true)] GetBoatsByPhoneRootRequestContract contract);
    
    [Post("/action/insertOne")]
    Task<BoatRootContract> SubmitDropRequestAsync([Body(true)] SubmitDropRequestRootRequestContract contract);
    
    [Post("/action/updateOne")]
    Task<BoatRootContract> UpdateBoatStatusAsync([Body(true)] UpdateBoatStatusRootRequestContract contract);

}