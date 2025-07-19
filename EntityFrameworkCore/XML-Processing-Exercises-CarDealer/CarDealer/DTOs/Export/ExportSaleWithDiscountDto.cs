namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleWithDiscountDto
    {
        [XmlElement("car")]
        public ExportCarWithPartsDto Car { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public double PriceWithDiscount { get; set; }
    }
}
