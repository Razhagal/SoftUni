namespace ProductShop.DTOs.Export
{
    public class ExportUsersWithSoldProductsDto
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ExportProductSoldWithBuyerNamesDto> SoldProducts { get; set; }
    }
}
