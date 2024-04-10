using System.Text.Json;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;

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
        var response = await _ownerBoatApi.GetBoatsByPhoneNumberAsync(new GetBoatsByPhoneRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
            Filter = new GetBoatsByPhoneFilterRequestContract() { OwnerPhoneNumber = phoneNumber},
        });

        return response.Documents;
    }
    
    public async Task SubmitDropRequestAsync(string boatNumber, string ownerId)
    {
        var contract = new SubmitDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Document = new SubmitDropRequestDocumentRequestContract()
            {
                RequestType = "drop_off",
                OwnerId = ownerId,
                BoatNumber = boatNumber,
                Status = "drop_request_submitted",
                Origin = new SubmitDropRequestLocationRequestContract()
                    { Dock = "ClubDock", Zone = "ClubZone", Latitude = 37.7749, Longitude = -122.4194 },
                Destination = new SubmitDropRequestLocationRequestContract()
                    { Dock = "Dock18", Zone = "Zone18", Latitude = 37.7749, Longitude = -122.4194 },
            }
        };

        var json = JsonSerializer.Serialize(contract);
        await _ownerBoatApi.SubmitDropRequestAsync(contract);
    }
    
    public async Task UpdateBoatStatusAsync(string boatNumber)
    {
        await _ownerBoatApi.UpdateBoatStatusAsync(new UpdateBoatStatusRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
            Filter = new UpdateBoatStatusFilterRequestContract() { BoatNumber = boatNumber },
            Update = new UpdateBoatStatusUpdateRequestContract() { UpdateBoatStatusUpdateSetRequestContract = new UpdateBoatStatusUpdateSetRequestContract() { RequestStatus = "drop_request_submitted"}}
        });
    }
}