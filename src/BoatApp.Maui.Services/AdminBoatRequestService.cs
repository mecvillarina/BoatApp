using BoatApp.Common.Constants;
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
                    new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.DropConfirmed },
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
                    new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.PickupConfirmed },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "pickup"}
                }
            }
        });
        
        return data.Documents;
    }

    public async Task<List<BoatRequestContract>> GetRecentRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                // And = new List<GetDropRequestAndOperatorRequestContract>()
                // {
                //     new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.DropRequestSubmitted },
                //     new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                // }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllConfirmedDropRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.DropConfirmed },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllInTransitDropRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.InTransitDrop },
                    new GetDropRequestAndOperatorRequestContract() { RequestType = "drop_off"}
                }
            }
        });
        
        return data.Documents;
    }
    
    public async Task<List<BoatRequestContract>> GetAllDropCompletedRequestsAsync()
    {
        var data = await _adminBoatRequestApi.GetAllDropRequestsAsync(new GetDropRequestRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new GetDropRequestFilterRequestContract()
            {
                And = new List<GetDropRequestAndOperatorRequestContract>()
                {
                    new GetDropRequestAndOperatorRequestContract() { Status = BoatRequestStatusConstants.DropOffCompleted },
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
             Filter = new ConfirmDropFilterRequestContract(){ BoatNumber = boatNumber},
             Update = new ConfirmDropUpdateRequestContract() { Set = new ConfirmDropUpdateSetRequestContract()
             {
                 Status = BoatRequestStatusConstants.DropConfirmed
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
                Filter = new MarkAsFilterRequestContract() { Status = BoatRequestStatusConstants.DropConfirmed },
                Update = new MarkAsUpdateRequestContract() { Set = new MarkAsUpdateSetRequestContract() { Status = BoatRequestStatusConstants.InTransitDrop }}
        });
    }
    
    public async Task MarkAsCompleteAsync()
    {
        await _adminBoatRequestApi.MarkAsCompleteAsync(new MarkAsRootRequestContract()
        {
            DataSource = "BoatCluster",
            Database = "BoatDB",
            Collection = "Requests",
            Filter = new MarkAsFilterRequestContract() { Status = BoatRequestStatusConstants.InTransitDrop },
            Update = new MarkAsUpdateRequestContract() { Set = new MarkAsUpdateSetRequestContract() { Status = BoatRequestStatusConstants.DropOffCompleted }}
        });
    }
}