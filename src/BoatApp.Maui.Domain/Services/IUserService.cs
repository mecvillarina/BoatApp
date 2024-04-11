using BoatApp.Common.Enums;
using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IUserService
{
    UserType? GetCurrentUserType();
    Task FetchAdminAsync();
    Task FetchUserByPhoneNumberAsync(string phoneNumber);
    OwnerContract GetUserProfile();
    string GetUserPhoneNumber();
    void ClearData();
}