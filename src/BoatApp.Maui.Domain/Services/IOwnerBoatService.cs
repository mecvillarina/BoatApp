using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IOwnerBoatService
{
    Task<List<BoatContract>> FetchBoatsByPhoneNumberAsync(string phoneNumber);
}