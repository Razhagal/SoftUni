namespace ProductShop.DTOs.Export
{
    public class ExportUsersSoldProductsWithCountDto
    {
        public int Count { get; set; }

        public ICollection<ExportProductNamePriceDto> Products { get; set; }
    }
}
