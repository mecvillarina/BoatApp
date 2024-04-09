namespace BoatApp.Maui.Domain.Services;

public interface IOwnerService
{
    Task FetchOwnerByPhoneNumberAsync(string phoneNumber);
}