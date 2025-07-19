namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCarDto
    {
        [Required]
        [JsonProperty("make")]
        public string Make { get; set; }

        [Required]
        [JsonProperty("model")]
        public string Model { get; set; }

        [Required]
        [JsonProperty("traveledDistance")]
        public long TraveledDistance { get; set; }

        [Required]
        [JsonProperty("partsId")]
        public int[] PartsId { get; set; }
    }
}
