using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IAdminBoatRequestService
{
    Task<List<BoatRequestContract>> GetScheduleDropRequestsAsync();
    Task<List<BoatRequestContract>> GetSchedulePickupRequestsAsync();

    Task<List<BoatRequestContract>> GetAllConfirmedDropRequestsAsync();
    Task<List<BoatRequestContract>> GetAllInTransitDropRequestsAsync();
    Task<List<BoatRequestContract>> GetAllDropCompletedRequestsAsync();
    
    Task ConfirmDropRequestAsync(string boatNumber);
    Task MarkAsTransitAsync();
    Task MarkAsCompleteAsync();
}