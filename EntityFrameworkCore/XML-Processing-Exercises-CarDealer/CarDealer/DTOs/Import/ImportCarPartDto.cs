namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class ImportCarPartDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
