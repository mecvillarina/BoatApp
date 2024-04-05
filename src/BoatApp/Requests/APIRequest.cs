using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatApp.Requests
{
    public class APIRequest
    {
        public string dataSource { get; set; }
        public string database { get; set; }
        public string collection { get; set; }

        public APIRequest()
        {
            dataSource = "BoatCluster";
            database = "BoatDB";
            collection = "Requests";
        }

    }
}
