using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using Refit;

namespace BoatApp.Maui.Services.Web.Api;

[Headers("Content-Type: application/json")]
public interface IAdminBoatRequestApi
{
    HttpClient Client { get; }
    
    
    [Post("/action/find")]
    Task<GenericListRootContract<object>> GetScheduleDropRequestsAsync([Body(true)] GetScheduleRequestRootRequestContract contract);
    
    [Post("/action/find")]
    Task<GenericListRootContract<object>> GetSchedulePickupRequestsAsync([Body(true)] GetScheduleRequestRootRequestContract contract);

    [Post("/action/updateOne")]
    Task ConfirmDropRequestAsync([Body(true)] ConfirmDropRootRequestContract contract);

    [Post("/action/updateOne")]
    Task MarkAsTransitAsync([Body(true)] MarkAsRootRequestContract contract);

    [Post("/action/updateOne")]
    Task MarkAsCompleteAsync([Body(true)] MarkAsRootRequestContract contract);

}