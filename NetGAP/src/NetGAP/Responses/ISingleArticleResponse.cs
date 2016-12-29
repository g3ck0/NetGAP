using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.Responses
{
    public interface ISingleArticleResponse<TModel> : IResponse
    {
        TModel Article { get; set; }
    }
}
