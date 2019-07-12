
using Newtonsoft.Json;
namespace PromoServiceMongoDB.Model
{
    public class ProductPromoCondition
    {
        public ProductPromoParameter parameter { get; set; }

        public ProductPromoOperator promoOperator { get; set; }

        public float conditionValue { get; set; }

        public float otherValue { get; set; }



        /* public ProductPromoCondition()
         {

         }*/

        public override string ToString()
        {
            // return JsonConvert.DeserializeObject(this);
            return JsonConvert.SerializeObject(this);
        }
    }
}