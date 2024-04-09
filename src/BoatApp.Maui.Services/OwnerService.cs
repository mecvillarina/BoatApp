using System.Text.Json;
using BoatApp.Common.Exceptions;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts.Requests;

namespace BoatApp.Maui.Services;

public class OwnerService : IOwnerService
{
    private readonly IOwnerApi _ownerApi;
    private readonly IPreferences _preferences;
    
    public OwnerService(IOwnerApi ownerApi, IPreferences preferences)
    {
        _ownerApi = ownerApi;
        _preferences = preferences;
    }

    public async Task FetchOwnerByPhoneNumberAsync(string phoneNumber)
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

        _preferences.Set("profile", JsonSerializer.Serialize(data), "owner");
    }
}