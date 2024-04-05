using BoatApp.Configs;
using BoatApp.Requests;
using System;
using System.Collections.Generic;
using NanoHandler.Handlers;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoatApp.Services
{
    public class BoatService
    {
        HttpClient _client;
        APICallHandler apiCallHandler;

        public BoatService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("api-key", "G1HLYwNa0jWevlzpenxkXMGAS79NUsMN5NmIYi7vqA4NP7pxSfFTZiEPBqeZKtGO");
            apiCallHandler = new APICallHandler(_client, AppConstants.RestUrl);
        }

        public async Task<string> ConfirmDropRequest(string boat_number)
        {
            ConfirmDropRequest request = new ConfirmDropRequest();
            request.filter.boat_number = boat_number;
            request.update.set.status = "drop_confirmed";

            string responseText = string.Empty;

            try
            {
                responseText = await apiCallHandler.SendRequestAsync<ConfirmDropRequest>("action/updateOne", request);

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseText;
        }

        public async Task<string> GetOwnerDetails()
        {
            OwnerRequest request = new OwnerRequest();
            request.collection = "Owners";
            request.filter.contact = "+1987654321";

            string responseText = string.Empty;

            try
            {
                responseText = await apiCallHandler.SendRequestAsync<OwnerRequest>("action/find", request);

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseText;
        }

        public async Task<string> GetBoatsByOwner()
        {
            BoatsRequest request = new BoatsRequest();
            request.collection = "Boats";
            request.filter.owner_id = "65fdd631af26f5fe426b290f";

            string responseText = string.Empty;

            try
            {
                responseText = await apiCallHandler.SendRequestAsync<BoatsRequest>("action/find", request);

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseText;
        }

        public async Task<string> SubmitDropRequest(string owner_id, string boat_number)
        {
            SubmitDropRequest request = new SubmitDropRequest();
            request.collection = "Requests";

            request.document.request_type = "POST";
            request.document.boat_number = boat_number;
            request.document.owner_id = owner_id;
            request.document.status = "pending";

            request.document.origin.dock = "ClubDock";
            request.document.origin.zone = "ClubZone";
            request.document.origin.latitude = 37.7749;
            request.document.origin.longitude = -122.4194;

            request.document.destination.dock = "Dock18";
            request.document.destination.zone = "Zone18";
            request.document.destination.latitude = 37.7749;
            request.document.destination.longitude = -122.4194;

            string responseText = string.Empty;

            try
            {
                responseText = await apiCallHandler.SendRequestAsync<SubmitDropRequest>("action/find", request);

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseText;
        }

        public async Task<string> GetAllRequests()
        {
            GenericRequest request = new GenericRequest();
            request.collection = "Boats";

            string responseText = string.Empty;

            try
            {
                responseText = await apiCallHandler.SendRequestAsync<GenericRequest>("action/find", request);

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseText;
        }

    }
}
