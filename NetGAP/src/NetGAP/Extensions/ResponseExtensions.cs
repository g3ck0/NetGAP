using System;
using System.Net;
using NetGAP.Responses;
using Microsoft.AspNetCore.Mvc;

namespace NetGAP.Extensions
{
    public static class ResponseExtensions
    {

        public static IActionResult ToHttpResponse<TModel>(this IListStoresResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.error_code>0)
            {
                status = HttpStatusCode.InternalServerError;
                response.success = false;
            }
            else if (response.Stores == null)
            {
                status = HttpStatusCode.NoContent;
                response.success = true;
            }
            else
            {
                response.success = true;
            }

            //return new ObjectResult(response) { StatusCode = (Int32)status };
            return new ObjectResult(response);
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleStoreResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.error_code > 0)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Store == null)
            {
                status = HttpStatusCode.NotFound;
            }

            //return new ObjectResult(response) { StatusCode = (Int32)status };
            return new ObjectResult(response);
        }

        public static IActionResult ToHttpResponse<TModel>(this IListArticlesResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.error_code > 0)
            {
                status = HttpStatusCode.InternalServerError;
                response.success = false;
            }
            else if (response.Articles == null)
            {
                status = HttpStatusCode.NoContent;
                response.success = true;
            }
            else
            {
                response.success = true;
            }

            //return new ObjectResult(response) { StatusCode = (Int32)status };
            return new ObjectResult(response);
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleArticleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.error_code > 0)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Article == null)
            {
                status = HttpStatusCode.NotFound;
            }

            //return new ObjectResult(response) { StatusCode = (Int32)status };
            return new ObjectResult(response);
        }
    }
}
