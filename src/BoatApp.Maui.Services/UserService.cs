using System.Text.Json;
using BoatApp.Common.Enums;
using BoatApp.Common.Exceptions;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts.Requests;

namespace BoatApp.Maui.Services;

public class UserService : IUserService
{
    private readonly IOwnerApi _ownerApi;
    private readonly IPreferences _preferences;
    
    public UserService(IOwnerApi ownerApi, IPreferences preferences)
    {
        _ownerApi = ownerApi;
        _preferences = preferences;
    }

    public UserType? GetCurrentUserType()
    {
        var admin = _preferences.Get<string>("profile", null, "admin");
        var user = _preferences.Get<string>("profile", null, "user");

        return admin != null ? UserType.Admin : (user != null ? UserType.User : null);
    }

    public async Task FetchAdminAsync()
    {
        _preferences.Set("profile", "su", "admin");
    }
    
    public async Task FetchUserByPhoneNumberAsync(string phoneNumber)
    {
        var response = await _ownerApi.GetOwnerByPhoneAsync(new GenericRequestContract<GetOwnerByPhoneRequestContract>()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Owners",
            Filter = new GetOwnerByPhoneRequestContract() { Contact = phoneNumber},
        });

        if (!response.Documents.Any())
        {
            throw new GeneralException("User not found");
        }

        var data = response.Documents.First();

        _preferences.Set("profile", JsonSerializer.Serialize(data), "user");
    }
}