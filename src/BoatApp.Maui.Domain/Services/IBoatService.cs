using BoatApp.Models;
using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IBoatService
{
    Task<List<BoatContract>> FetchBoatsByPhoneNumberAsync(string phoneNumber);
    Task SubmitDropRequestAsync(SubmitDropRequestParameter parameter);
    Task UpdateBoatStatusAsync(string boatNumber, string status);
}