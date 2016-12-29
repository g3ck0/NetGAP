using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public interface IResponse
    {
        int error_code { get; set; }

        String error_message { get; set; }

        Boolean success { get; set; }
    }
}
