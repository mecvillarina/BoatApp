namespace BoatApp.Maui.Domain.Services;

public interface IAdminBoatRequestService
{
    Task<int> GetScheduleDropRequestsCountAsync();
    Task<int> GetSchedulePickupRequestsCountAsync();
    
    Task ConfirmDropRequestAsync(string boatNumber);
    Task MarkAsTransitAsync();
    Task MarkAsCompleteAsync();
}