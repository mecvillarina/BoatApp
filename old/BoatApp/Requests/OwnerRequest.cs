using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Requests
{
    public class OwnerRequest:APIRequest
    {
        public ContactNumberFilter filter { get; set; }
        public OwnerRequest() { 
            filter = new ContactNumberFilter();
        }
    }

    public class ContactNumberFilter
    {
        public string contact { get; set; }
    }

    public class BoatsRequest : APIRequest
    {
        public OwnerIdFilter filter { get; set; }
        public BoatsRequest()
        {
            filter = new OwnerIdFilter();
        }
    }

    public class OwnerIdFilter
    {
        public string owner_id { get; set; }
    }

    public class SubmitDropRequest : APIRequest
    {
        public RequestDetails document { get; set; }
        public SubmitDropRequest()
        {
            document = new RequestDetails();
        }
    }

    public class Destination
    {
        public string dock { get; set; }
        public string zone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class RequestDetails
    {
        public string request_type { get; set; }
        public string boat_number { get; set; }
        public string owner_id { get; set; }
        public string status { get; set; }
        public Origin origin { get; set; }
        public Destination destination { get; set; }

        public RequestDetails()
        {
            origin = new Origin();
            destination = new Destination();
        }
    }

    public class Origin
    {
        public string dock { get; set; }
        public string zone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

}
