namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public ImportCarPartDto[] Parts { get; set; }
    }
}
