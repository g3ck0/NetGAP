using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public interface IListStoresResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Stores { get; set; }
    }
}
