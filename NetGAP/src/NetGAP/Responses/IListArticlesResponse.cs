using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public interface IListArticlesResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Articles { get; set; }
    }
}
