using System.Text.Json;
using BoatApp.Common.Constants;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models;
using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;
using DryIoc.ImTools;

namespace BoatApp.Maui.Services;

public class BoatService : IBoatService
{
    private readonly IOwnerBoatApi _boatApi;
    private readonly IOwnerApi _ownerApi;
    public BoatService(IOwnerBoatApi boatApi, IOwnerApi ownerApi)
    {
        _boatApi = boatApi;
        _ownerApi = ownerApi;
    }

    public async Task<List<BoatContract>> FetchBoatsByPhoneNumberAsync(string phoneNumber)
    {
        var response = await _boatApi.GetBoatsByPhoneNumberAsync(new GetBoatsByPhoneRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
            Filter = new GetBoatsByPhoneFilterRequestContract() { OwnerPhoneNumber = phoneNumber},
        });

        return response.Documents;
    }
    
    public async Task<List<CustomOwnerBoat>> FetchBoatsAsync()
    {
        var ownerListResponse = await _ownerApi.GetOwnersAsync(new GetOwnersRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Owners",
        });

        var boatListResponse = await _boatApi.GetBoatsAsync(new GetBoatsRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
        });

        var ownerList = ownerListResponse.Documents;
        var boatList = boatListResponse.Documents;
        var boats = new List<CustomOwnerBoat>();
        
        foreach (var boat in boatList)
        {
            var owner = ownerList.FirstOrDefault(x => x.Id == boat.OwnerId);
            if (owner != null)
            {
                boats.Add(new CustomOwnerBoat()
                {
                    Boat = boat,
                    Owner = owner
                });
            }
        }

        return boats;
    }
    
    public async Task SubmitDropRequestAsync(SubmitDropRequestParameter parameter)
    {
        var contract = new SubmitDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Document = new SubmitDropRequestDocumentRequestContract()
            {
                RequestType = "drop_off",
                BoatName = parameter.BoatName,
                BoatNumber = parameter.BoatNumber,
                BoatImageUrl = parameter.BoatImageUrl,
                OwnerId = parameter.OwnerId,
                OwnerName = parameter.OwnerName,
                PickupPoint = parameter.PickupPoint,
                PickupDate = parameter.PickupDate,
                Status = BoatRequestStatusConstants.DropRequestSubmitted,
                Origin = new SubmitDropRequestLocationRequestContract()
                    { Dock = "ClubDock", Zone = "ClubZone", Latitude = 37.7749, Longitude = -122.4194 },
                Destination = new SubmitDropRequestLocationRequestContract()
                    { Dock = "Dock18", Zone = "Zone18", Latitude = 37.7749, Longitude = -122.4194 },
            }
        };

        var json = JsonSerializer.Serialize(contract);
        await _boatApi.SubmitDropRequestAsync(contract);
    }
    
    public async Task UpdateBoatStatusAsync(string boatNumber, string status)
    {
        await _boatApi.UpdateBoatStatusAsync(new UpdateBoatStatusRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Boats",
            Filter = new UpdateBoatStatusFilterRequestContract() { BoatNumber = boatNumber },
            Update = new UpdateBoatStatusUpdateRequestContract() { Set = new UpdateBoatStatusUpdateSetRequestContract() { RequestStatus = status}}
        });
    }

   
}