using ProductShop.Data;
using ProductShop.Models;
using ProductShop.DTOs.Import;
using ProductShop.DTOs.Export;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.ComponentModel.DataAnnotations;

using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            mapper = config.CreateMapper();

            string jsonFile = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportUsers(dbContext, jsonFile);
            //string result = ImportProducts(dbContext, jsonFile);
            //string result = ImportCategories(dbContext, jsonFile);
            //string result = ImportCategoryProducts(dbContext, jsonFile);
            //string result = GetProductsInRange(dbContext);
            //string result = GetSoldProducts(dbContext);
            //string result = GetCategoriesByProductsCount(dbContext);
            string result = GetUsersWithProducts(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = "";

            ImportUserDto[]? importedUsersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            if (importedUsersDtos != null)
            {
                ICollection<User> usersToAdd = new List<User>();
                foreach (var userDto in importedUsersDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    if (userDto.Age != null)
                    {
                        bool ageIsValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!ageIsValid)
                        {
                            continue;
                        }
                    }

                    User user = mapper.Map<ImportUserDto, User>(userDto);
                    usersToAdd.Add(user);
                }

                context.Users.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = "";

            ImportProductDto[]? importedProductsDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            if (importedProductsDtos != null)
            {
                ICollection<Product> productsToAdd = new List<Product>();
                foreach (var productDto in importedProductsDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal parsedPrice);
                    bool isSellerIdValid = int.TryParse(productDto.SellerId, out int parsedSelledId);
                    if (!isPriceValid || !isSellerIdValid)
                    {
                        continue;
                    }

                    //int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerIdValid)
                        {
                            continue;
                        }

                        //buyerId = parsedBuyerId;
                    }

                    // TODO: Should validate if Seller and Buyer Id's are valid users. Otherwise skip product because of invalid data
                    Product product = mapper.Map<ImportProductDto, Product>(productDto);

                    //Product product = new Product()
                    //{
                    //    Name = productDto.Name,
                    //    Price = parsedPrice,
                    //    SellerId = parsedSelledId,
                    //    BuyerId = buyerId
                    //};
                    productsToAdd.Add(product);
                }

                context.Products.AddRange(productsToAdd);
                context.SaveChanges();

                result = $"Successfully imported {productsToAdd.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = "";

            ImportCategoryDto[]? importedCategoriesDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            if (importedCategoriesDtos != null)
            {
                ICollection<Category> categoriesToAdd = new List<Category>();
                foreach (var categoryDto in importedCategoriesDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category category = mapper.Map<ImportCategoryDto, Category>(categoryDto);
                    //Category category = new Category()
                    //{
                    //    Name = categoryDto.Name
                    //};
                    categoriesToAdd.Add(category);
                }

                context.Categories.AddRange(categoriesToAdd);
                context.SaveChanges();

                result = $"Successfully imported {categoriesToAdd.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = "";

            ImportCategoryProductDto[]? importedCategoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            if (importedCategoryProductDtos != null)
            {
                //var productIds = context.Products
                //    .Select(p => p.Id)
                //    .ToList();

                //var categoryIds = context.Categories
                //    .Select(c => c.Id)
                //    .ToList();

                ICollection<CategoryProduct> categoriesProductsToAdd = new List<CategoryProduct>();
                foreach (var categoryProductDto in importedCategoryProductDtos)
                {
                    if (!IsValid(categoryProductDto))
                    {
                        continue;
                    }

                    bool isValidCategoryId = int.TryParse(categoryProductDto.CategoryId, out int parsedCategoryId);
                    bool isValidProductId = int.TryParse(categoryProductDto.ProductId, out int parsedProductId);
                    if (!isValidCategoryId || !isValidProductId)
                    {
                        continue;
                    }

                    // TODO: Check for foreign key violation by trying to insert data with nonexistant Ids for Products or Categories
                    CategoryProduct categoryProduct = mapper.Map<ImportCategoryProductDto, CategoryProduct>(categoryProductDto);

                    //CategoryProduct categoryProduct = new CategoryProduct()
                    //{
                    //    CategoryId = parsedCategoryId,
                    //    ProductId = parsedProductId
                    //};
                    categoriesProductsToAdd.Add(categoryProduct);
                }

                context.CategoriesProducts.AddRange(categoriesProductsToAdd);
                context.SaveChanges();

                result = $"Successfully imported {categoriesProductsToAdd.Count}";
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
                //.Select(x => new
                //{
                //    Name = x.Name,
                //    Price = x.Price,
                //    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                //})
                .OrderBy(x => x.Price)
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            };

            string jsonResult = JsonConvert.SerializeObject(productsInRange, Formatting.Indented, serializerSettings);
            return jsonResult;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .ProjectTo<ExportUsersWithSoldProductsDto>(mapper.ConfigurationProvider)
                //.Select(u => new
                //{
                //    FirstName = u.FirstName,
                //    LastName = u.LastName,
                //    SoldProducts = u.ProductsSold
                //        .Where(p => p.BuyerId.HasValue)
                //        .Select(p => new
                //        {
                //            Name = p.Name,
                //            Price = p.Price,
                //            BuyerFirstName = p.Buyer.FirstName,
                //            BuyerLastName = p.Buyer.LastName
                //        })
                //        .ToList()
                //})
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });
            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .ProjectTo<ExportCategoriesByProductsCountDto>(mapper.ConfigurationProvider)
                //.Select(c => new
                //{
                //    Category = c.Name,
                //    ProductsCount = c.CategoriesProducts.Count,
                //    AveragePrice = (c.CategoriesProducts.Sum(p => p.Product.Price) / c.CategoriesProducts.Count).ToString("F2"),
                //    TotalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("F2")
                //})
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings serializerSetting = new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            };

            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented, serializerSetting);
            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .ProjectTo<ExportUsersDataWithProductsSoldDto>(mapper.ConfigurationProvider)
                //.Select(u => new
                //{
                //    FirstName = u.FirstName,
                //    LastName = u.LastName,
                //    Age = u.Age,
                //    SoldProducts = new
                //    {
                //        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                //        Products = u.ProductsSold
                //            .Where(p => p.BuyerId.HasValue)
                //            .Select(p => new
                //            {
                //                Name = p.Name,
                //                Price = p.Price
                //            })
                //            .ToList()
                //    }
                //})
                .ToList()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var serializedUsers = new
            {
                UsersCount = usersWithProducts.Count,
                Users = usersWithProducts
            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore
            };

            string jsonResult = JsonConvert.SerializeObject(serializedUsers, Formatting.Indented, serializerSettings);
            return jsonResult;
        }

        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResult);

            return isValid;
        }
    }
}