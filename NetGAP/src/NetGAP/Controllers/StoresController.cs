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

namespace NetGAP.Controllers
{
    [Route("services/[controller]")]
    public class StoresController : Controller
    {

        private readonly TiendaContext _context;

        public StoresController(TiendaContext context)
        {
            _context = context;
        }

        // GET services/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new ListStoresResponse<StoreViewModel>() as IListStoresResponse<StoreViewModel>;

            try
            {
                StoreRepository db = new DataLayer.StoreRepository(_context);
                response.Stores = await Task.Run(() =>
                {
                    return db.GetStores().Select(item => item.ToViewModel()).ToList();
                });
            }
            catch(Exception ex)
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
            var response = new SingleStoreResponse<StoreViewModel>() as ISingleStoreResponse<StoreViewModel>;

            try
            {
                StoreRepository db = new DataLayer.StoreRepository(_context);
                response.Store = await Task.Run(() =>
                {
                    return db.GetStore(id).ToViewModel();
                });
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
        public async Task<IActionResult> Post([FromForm]StoreViewModel value)
        {
            var response = new SingleStoreResponse<StoreViewModel>() as ISingleStoreResponse<StoreViewModel>;

            try
            {
                StoreRepository db = new DataLayer.StoreRepository(_context);
                var entity = await Task.Run(() =>
                {
                    return db.AddStore(value.ToEntity());
                });

                response.Store = entity.ToViewModel();
                response.error_message = "Store saved succesfully";
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE services/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
