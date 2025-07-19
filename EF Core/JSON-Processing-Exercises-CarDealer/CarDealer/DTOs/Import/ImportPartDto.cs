namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportPartDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public string Price { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [Required]
        [JsonProperty("supplierId")]
        public string SupplierId { get; set; }
    }
}
