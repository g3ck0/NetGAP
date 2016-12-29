using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public class SingleStoreResponse<TModel> : ISingleStoreResponse<TModel>
    {
        public int error_code { get; set; }

        public String error_message { get; set; }

        public Boolean success { get; set; }

        public TModel Store { get; set; }
    }
}
