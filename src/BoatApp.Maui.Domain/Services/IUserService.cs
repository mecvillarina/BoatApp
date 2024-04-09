using BoatApp.Common.Enums;

namespace BoatApp.Maui.Domain.Services;

public interface IUserService
{
    UserType? GetCurrentUserType();
    Task FetchAdminAsync();
    Task FetchUserByPhoneNumberAsync(string phoneNumber);
}