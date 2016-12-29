using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public class ListStoresResponse<TModel> : IListStoresResponse<TModel>
    {
        public int error_code { get; set; }

        public String error_message { get; set; }

        public Boolean success { get; set; }

        public IEnumerable<TModel> Stores { get; set; }
    }
}
