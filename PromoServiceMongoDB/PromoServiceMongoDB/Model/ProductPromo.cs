using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PromoServiceMongoDB.Model
{
    public class ProductPromo
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string name { get; set; }

      
        public string code { get; set; }

       
        public string description { get; set; }

       
        public string imageRef { get; set; }

        public string tenant { get; set; }


        public string fromDate { get; set; }

        public string throughDate { get; set; }

       // [BsonElement("LimitPerCust")]
        public int useLimitPerCustomer { get; set; }


       // [BsonElement("LimitPerCode")]
        public int useLimitPerCode { get; set; }


       // [BsonElement("Condition")]
        public List<ProductPromoCondition> conditions { get; set; }


       // [BsonElement("action")]
        public ProductPromoAction action { get; set; }



        /* ProductPromo pp = new ProductPromo();
         string serializedJson = JsonConvert.SerializeObject(pp);*/



        public override string ToString()
        {
           // return JsonConvert.DeserializeObject(this);
           return JsonConvert.SerializeObject(this);
        }


       /* public ProductPromo()
        {
           *//* ProductPromo pp = new ProductPromo();
            string serializedJson = JsonConvert.SerializeObject(pp);*//*
        }*/
    }


}

