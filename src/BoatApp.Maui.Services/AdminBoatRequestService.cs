using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts;
using BoatApp.Models.Contracts.Requests;

namespace BoatApp.Maui.Services;

public class AdminBoatRequestService : IAdminBoatRequestService
{
    private readonly IAdminBoatRequestApi _adminBoatRequestApi;

    public AdminBoatRequestService(IAdminBoatRequestApi adminBoatRequestApi)
    {
        _adminBoatRequestApi = adminBoatRequestApi;
    }

    public async Task<List<BoatRequestContract>> GetScheduleDropRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetScheduleDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = "drop_request_submitted" },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });

        return data.Documents;
    }

    public async Task<List<BoatRequestContract>> GetSchedulePickupRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetSchedulePickupRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = "pickup_request_submitted" },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "pickup"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllConfirmedDropRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllConfirmedDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = "drop_confirmed" },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllInTransitDropRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllInTransitDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = "in_transit_drop" },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllDropCompletedRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllDropCompletedRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = "dropoff_completed" },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task ConfirmDropRequestAsync(string boatNumber)
    {
       await  _adminBoatRequestApi.ConfirmDropRequestAsync(new ConfirmDropRootRequestContract()
        {
             DataSource = "BoatCluster",
             Database = "BoatDB",
             Collection ="Requests",
             Filter = new ConfirmDropFilterRequestContract(){ BoatNumber =boatNumber},
             Update = new ConfirmDropUpdateRequestContract() { Set = new ConfirmDropUpdateSetRequestContract()
             {
                 Status = "drop_confirmed"
             }}
        });
    }

    public async Task MarkAsTransitAsync()
    {
        await _adminBoatRequestApi.MarkAsTransitAsync(new MarkAsRootRequestContract()
        {
                DataSource = "BoatCluster",
                Database = "BoatDB",
                Collection = "Requests",
                Filter = new MarkAsFilterRequestContract() { Status = "drop_confirmed" },
                Update = new MarkAsUpdateRequestContract() { Set = new MarkAsUpdateSetRequestContract() { Status = "in_transit_drop"}}
        });
    }
    
    public async Task MarkAsCompleteAsync()
    {
        await _adminBoatRequestApi.MarkAsCompleteAsync(new MarkAsRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new MarkAsFilterRequestContract() { Status = "in_transit_drop" },
            Update = new MarkAsUpdateRequestContract() { Set = new MarkAsUpdateSetRequestContract() { Status = "dropoff_completed"}}
        });
    }
}