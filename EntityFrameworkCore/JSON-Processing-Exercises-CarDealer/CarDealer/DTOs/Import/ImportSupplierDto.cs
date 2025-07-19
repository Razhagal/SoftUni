namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class ImportSupplierDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("isImporter")]
        public string IsImporter { get; set; }
    }
}
