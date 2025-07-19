using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import
{

    public class ImportProductDto
    {
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("Price")]
        public string Price { get; set; }

        [Required]
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        [JsonProperty("BuyerId")]
        public string? BuyerId { get; set; }
    }
}
