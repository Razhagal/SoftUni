namespace ProductShop.DTOs.Export
{
    public class ExportUsersDataWithProductsSoldDto
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ExportUsersSoldProductsWithCountDto SoldProducts { get; set; }
    }
}
