using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuideWithTourPackagesDto
    {
        [XmlElement(nameof(FullName))]
        public string FullName { get; set; } = null!;

		[XmlArray(nameof(TourPackages))]
        public ExportTourPackageDto[] TourPackages { get; set; }
    }
}