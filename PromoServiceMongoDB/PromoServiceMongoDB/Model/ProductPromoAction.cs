using Newtonsoft.Json;

namespace PromoServiceMongoDB.Model
{
    public class ProductPromoAction
    {
        public ProductPromoActionType type { get; set; }
        public decimal quantity { get; set; }
        public decimal amount { get; set; }

        public string productId { get; set; }

        public string catalogId { get; set; }


        /* public ProductPromoAction()
         {

         }
 */
        public override string ToString()
        {
            // return JsonConvert.DeserializeObject(this);
            return JsonConvert.SerializeObject(this);
        }


    }
}