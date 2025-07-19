namespace ProductShop.DTOs.Export
{
    public class ExportCategoriesByProductsCountDto
    {
        public string Category { get; set; }

        public int ProductsCount { get; set; }

        public string AveragePrice { get; set; }

        public string TotalRevenue { get; set; }
    }
}
