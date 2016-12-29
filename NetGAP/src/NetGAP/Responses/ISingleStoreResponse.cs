using System;

namespace NetGAP.Responses
{
    public interface ISingleStoreResponse<TModel> : IResponse
    {
        TModel Store { get; set; }
    }
}
