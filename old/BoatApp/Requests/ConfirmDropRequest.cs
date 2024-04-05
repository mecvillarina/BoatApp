using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoatApp.Requests
{
    public class ConfirmDropRequest: APIRequest
    {
        public ConfirmDropFilter filter { get; set; }
        public ConfirmDropUpdate update { get; set; }

        public ConfirmDropRequest()
        {
            filter=new ConfirmDropFilter();
            update=new ConfirmDropUpdate();
        }
    }

    public class ConfirmDropFilter
    {
        public string boat_number { get; set; }
    }

    public class ConfirmDropUpdate
    {
        //[JsonProperty("$set")]
        public ConfirmDropUpdateSet set { get; set; }
        public ConfirmDropUpdate()
        {
            set = new ConfirmDropUpdateSet();
        }
    }

    public class ConfirmDropUpdateSet
    {
        public string status { get; set; }
    }
}
