using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IBoatService
{
    Task<List<BoatContract>> FetchBoatsByPhoneNumberAsync(string phoneNumber);
    Task SubmitDropRequestAsync(string boatNumber, string ownerId, string ownerName, string boatImageUrl,
        string pickupPoint, string pickupDate);
    Task UpdateBoatStatusAsync(string boatNumber, string status);
}