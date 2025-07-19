namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.DTOs.Import;
    using ProductShop.DTOs.Export;

    using System.Xml.Serialization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            //string xmlInput = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportUsers(dbContext, xmlInput);
            //string result = ImportProducts(dbContext, xmlInput);
            //string result = ImportCategories(dbContext, xmlInput);
            //string result = ImportCategoryProducts(dbContext, xmlInput);

            //string result = GetProductsInRange(dbContext);
            //string result = GetSoldProducts(dbContext);
            //string result = GetCategoriesByProductsCount(dbContext);
            string result = GetUsersWithProducts(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string result = "";
            ImportUserDto[]? importedUserDtos = DeserializeXml<ImportUserDto[]>(inputXml, "Users");
            if (importedUserDtos != null)
            {
                var users = importedUserDtos
                    .Select(u => new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age <= 0 ? null : u.Age
                    })
                    .ToList();

                context.Users.AddRange(users);
                context.SaveChanges();

                result = $"Successfully imported {users.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string result = "";
            ImportProductDto[]? importedProductDtos = DeserializeXml<ImportProductDto[]>(inputXml, "Products");
            if (importedProductDtos != null)
            {
                var products = importedProductDtos
                    .Select(p => new Product()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        SellerId = p.SellerId,
                        BuyerId = p.BuyerId == 0 ? null : p.BuyerId
                    })
                    .ToList();

                context.Products.AddRange(products);
                context.SaveChanges();

                result = $"Successfully imported {products.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = "";
            ImportCategoryDto[]? importedCategoryDtos = DeserializeXml<ImportCategoryDto[]>(inputXml, "Categories");
            if (importedCategoryDtos != null)
            {
                var categories = importedCategoryDtos
                    .Select(c => new Category()
                    {
                        Name = c.Name
                    })
                    .ToList();

                context.Categories.AddRange(categories);
                context.SaveChanges();

                result = $"Successfully imported {categories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result = "";
            ImportCategoryProductDto[]? importedCategoryProductDtos = DeserializeXml<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            if (importedCategoryProductDtos != null)
            {
                var categoriesProducts = importedCategoryProductDtos
                    .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                            context.Products.Any(p => p.Id == cp.ProductId))
                    .Select(cp => new CategoryProduct()
                    {
                        CategoryId = cp.CategoryId,
                        ProductId = cp.ProductId
                    })
                    .ToList();

                context.CategoryProducts.AddRange(categoriesProducts);
                context.SaveChanges();

                result = $"Successfully imported {categoriesProducts.Count}";
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInPriceRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToList();

            return SerializeToXml(productsInPriceRange, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUsersWithSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new ExportSoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            return SerializeToXml(usersWithSoldProducts, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryByProductsSoldDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            return SerializeToXml(categories, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUserFullDataDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new ExportSoldProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var finalExportDto = new ExportUsersWithProductsFullDto()
            {
                Count = context.Users.Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue)).Count(),
                Users = usersWithSoldProducts
            };

            return SerializeToXml(finalExportDto, "Users");
        }

        private static T DeserializeXml<T>(string inputXml, string xmlRoot)
        {
            XmlRootAttribute rootAttr = new XmlRootAttribute(xmlRoot);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttr);

            T result = (T)serializer.Deserialize(new StringReader(inputXml));
            return result;
        }

        private static string SerializeToXml<T>(T dtoObj, string xmlRoot)
        {
            XmlRootAttribute rootAttr = new XmlRootAttribute(xmlRoot);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttr);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dtoObj, xmlNamespaces);
            }

            return sb.ToString();
        }
    }
}