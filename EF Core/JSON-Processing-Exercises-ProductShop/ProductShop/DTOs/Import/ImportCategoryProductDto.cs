using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoryProductDto
    {
        [Required]
        [JsonProperty("CategoryId")]
        public string CategoryId { get; set; }

        [Required]
        [JsonProperty("ProductId")]
        public string ProductId { get; set; }
    }
}
