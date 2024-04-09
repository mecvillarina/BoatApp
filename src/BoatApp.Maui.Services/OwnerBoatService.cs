using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using DryIoc.ImTools;

namespace BoatApp.Maui.Services;

public class OwnerBoatService : IOwnerBoatService
{
    private readonly IOwnerBoatApi _ownerBoatApi;
    
    public OwnerBoatService(IOwnerBoatApi ownerBoatApi)
    {
        _ownerBoatApi = ownerBoatApi;
    }

    public async Task<List<BoatContract>> FetchBoatsByPhoneNumberAsync(string phoneNumber)
    {
        var response = await _ownerBoatApi.GetBoatsByPhoneNumberAsync(new GenericRequestContract<GetBoatsByPhoneRequestContract>()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
            Filter = new GetBoatsByPhoneRequestContract() { OwnerPhoneNumber = phoneNumber},
        });

        return response.Documents;
    }
}