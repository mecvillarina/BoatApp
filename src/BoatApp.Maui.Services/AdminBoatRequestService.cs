using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.Services.Web.Api;
using BoatApp.Models.Contracts.Requests;

namespace BoatApp.Maui.Services;

public class AdminBoatRequestService : IAdminBoatRequestService
{
    private readonly IAdminBoatRequestApi _adminBoatRequestApi;

    public AdminBoatRequestService(IAdminBoatRequestApi adminBoatRequestApi)
    {
        _adminBoatRequestApi = adminBoatRequestApi;
    }

    public async Task<int> GetScheduleDropRequestsCountAsync()
    {
        var data = await _adminBoatRequestApi.GetScheduleDropRequestsAsync(new GetScheduleRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetScheduleRequestFilterRequestContract()
            {
                And = new List<GetScheduleRequestAndOperatorRequestContract>()
                {
                    new GetScheduleRequestAndOperatorRequestContract() { Status = "drop_request_submitted" },
                    new GetScheduleRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });

        return data.Documents.Count;
    }

    public async Task<int> GetSchedulePickupRequestsCountAsync()
    {
        var data = await _adminBoatRequestApi.GetSchedulePickupRequestsAsync(new GetScheduleRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetScheduleRequestFilterRequestContract()
            {
                And = new List<GetScheduleRequestAndOperatorRequestContract>()
                {
                    new GetScheduleRequestAndOperatorRequestContract() { Status = "pickup_request_submitted" },
                    new GetScheduleRequestAndOperatorRequestContract() { RequestType = "pickup"}
                }
            }
        });
        
        return data.Documents.Count;
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