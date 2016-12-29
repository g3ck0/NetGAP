using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetGAP.ViewModels;
using NetGAP.Models;
using NetGAP.DataLayer;
using NetGAP.Responses;
using NetGAP.Extensions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetGAP.Controllers
{
    [Route("services/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly TiendaContext _context;

        public ArticlesController(TiendaContext context)
        {
            _context = context;
        }

        // GET: services/articles/stores
        [HttpGet("stores/{id}")]
        public async Task<IActionResult> stores(long id)
        {
            var response = new ListArticlesResponse<ArticleViewModel>() as IListArticlesResponse<ArticleViewModel>;

            try
            {
                ArticleRepository db = new ArticleRepository(_context);
                response.Articles = await Task.Run(() =>
                {
                    return db.GetArticlesByStore(id).Select(item => item.ToViewModel()).ToList();
                });
                response.success = true;
            }
            catch (Exception ex)
            {
                response.error_code = 500;
                response.error_message = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // GET services/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = new SingleArticlesResponse<ArticleViewModel>() as ISingleArticleResponse<ArticleViewModel>;

            try
            {
                ArticleRepository db = new DataLayer.ArticleRepository(_context);
                response.Article = await Task.Run(() =>
                {
                    return db.GetArticle(id).ToViewModel();
                });
                response.success = true;
            }
            catch (Exception ex)
            {
                response.error_code = 500;
                response.error_message = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // POST services/values
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]ArticleViewModel value)
        {
            var response = new SingleArticlesResponse<ArticleViewModel>() as ISingleArticleResponse<ArticleViewModel>;

            try
            {
                ArticleRepository db = new DataLayer.ArticleRepository(_context);
                var entity = await Task.Run(() =>
                {
                    return db.AddArticle(value.ToEntity());
                });

                response.Article = entity.ToViewModel();
                response.error_message = "Article saved succesfully";
                response.success = true;
            }
            catch (Exception ex)
            {
                response.error_code = 500;
                response.error_message = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // PUT services/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromForm]ArticleViewModel value)
        {
            var response = new SingleArticlesResponse<ArticleViewModel>() as ISingleArticleResponse<ArticleViewModel>;

            try
            {
                ArticleRepository db = new DataLayer.ArticleRepository(_context);
                var entity = await Task.Run(() =>
                {
                    return db.UpdateArticle(id, value.ToEntity());
                });

                response.Article = entity.ToViewModel();
                response.error_message = "Article saved succesfully";
                response.success = true;
            }
            catch (Exception ex)
            {
                response.error_code = 500;
                response.error_message = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // DELETE services/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new SingleArticlesResponse<ArticleViewModel>() as ISingleArticleResponse<ArticleViewModel>;

            try
            {
                ArticleRepository db = new DataLayer.ArticleRepository(_context);
                var entity = await Task.Run(() =>
                {
                    return db.DeleteArticle(id);
                });

                response.Article = entity.ToViewModel();
                response.error_message = "Article deleted succesfully";
                response.success = true;
            }
            catch (Exception ex)
            {
                response.error_code = 500;
                response.error_message = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
