using BoatApp.Common.Enums;
using BoatApp.Models.Contracts;

namespace BoatApp.Maui.Domain.Services;

public interface IUserService
{
    UserType? GetCurrentUserType();
    void SaveAdminProfile();
    void SaveUserProfile(OwnerContract data);
    Task<OwnerContract> FetchUserByPhoneNumberAsync(string phoneNumber);
    OwnerContract GetUserProfile();
    string GetUserPhoneNumber();
    void ClearData();
}