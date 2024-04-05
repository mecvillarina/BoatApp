using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoatApp.Requests
{
    public class GenericRequest : APIRequest
    {
        public GenericFilter filter { get; set; }

        public GenericRequest()
        {
            filter=new GenericFilter();
        }
    }

    public class GenericFilter
    {

    }

}
