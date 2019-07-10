using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoServiceMongoDB.Model;
using PromoServiceMongoDB.DataAccess;
//using Microsoft.AspNetCore.Mvc;

namespace PromoServiceMongoDB.Controllers
{

    [Route("/v1/promotions")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        ICosmosDataAdapter _adapter;
        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            

            var result = await _adapter.Get();
            return Ok(result);
        }


        [HttpPost]
        public async Task<JsonResult> CreateDocument([FromBody] ProductPromo productpromo)
        {
            await _adapter.CreateDocument("PromoService", "ProductPromo", productpromo);

            return new JsonResult(productpromo);
           // return Ok(result);
        }

    }
}
