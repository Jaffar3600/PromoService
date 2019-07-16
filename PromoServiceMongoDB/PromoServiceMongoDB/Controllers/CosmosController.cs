using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoServiceMongoDB.Model;
using PromoServiceMongoDB.DataAccess;
using PromoServiceMongoDB.DataAccess.Utility;
//using Microsoft.AspNetCore.Mvc;

namespace PromoServiceMongoDB.Controllers
{

    [Route("/v1/promotions")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        ICosmosDataAdapter _adapter;

        /* public CosmosController()
         {
         }*/

        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }




        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] ProductPromo productpromo)
        {
            var result = await _adapter.CreateDocument("PromoDatabase", "ProductPromo", productpromo);
            return Ok(result);
        }

        /* [HttpPut]
         public async Task<IActionResult> Update([FromBody] ProductPromo productpromo)
         {
             var result = await _adapter.updateDocumentAsync("PromoDatabase", "ProductPromo", productpromo);
             return Ok(result);
         }*/


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Console.Write("hi");
            var result = await _adapter.DeleteUserAsync("PromoDatabase", "ProductPromo", id);
            return Ok(result);
        }





        /*       [HttpDelete]
          // [ActionName("Delete")]
           public async Task<ActionResult> DeleteAsync(string id, string tenant)
           {


              var result = await _adapter.DeleteUserAsync<ProductPromo>.GetItemAsync(id, tenant);

               return Ok(result);
           }*/






        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _adapter.GetDataAsync("PromoDatabase", "ProductPromo");
            return Ok(result);
        }


        [HttpPut("{id}/action")]
        public async Task<IActionResult> Update([FromBody] ProductPromoAction productpromoaction, string id)
        {
            var result = await _adapter.updateDocumentAsync("PromoDatabase", "ProductPromoAction", productpromoaction, id);
            return Ok(result);
        }


        [HttpPost("action")]
        public async Task<IActionResult> CreateAction([FromBody] ProductPromoAction productpromoaction)
        {
            var result = await _adapter.CreateDocument("PromoDatabase", "ProductPromoAction", productpromoaction);
            return Ok(result);
        }




    }
}
