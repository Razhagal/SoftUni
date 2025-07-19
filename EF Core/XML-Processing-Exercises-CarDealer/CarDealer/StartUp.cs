namespace CarDealer
{
    using Models;
    using Data;
    using DTOs.Import;

    using System.Xml.Serialization;
    using System.Text;
    using CarDealer.DTOs.Export;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            //string xmlInput = File.ReadAllText("../../../Datasets/sales.xml");
            //string result = ImportSuppliers(dbContext, xmlInput);
            //string result = ImportParts(dbContext, xmlInput);
            //string result = ImportCars(dbContext, xmlInput);
            //string result = ImportCustomers(dbContext, xmlInput);
            //string result = ImportSales(dbContext, xmlInput);

            //string result = GetCarsWithDistance(dbContext);
            //string result = GetCarsFromMakeBmw(dbContext);
            //string result = GetLocalSuppliers(dbContext);
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //string result = GetTotalSalesByCustomer(dbContext);
            string result = GetSalesWithAppliedDiscount(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = "";
            ImportSupplierDto[]? importedSupplierDtos = DeserializeXml<ImportSupplierDto[]>(inputXml, "Suppliers");
            if (importedSupplierDtos != null)
            {
                var suppliers = importedSupplierDtos
                    .Select(s => new Supplier()
                    {
                        Name = s.Name,
                        IsImporter = s.IsImporter
                    })
                    .ToList();

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                result = $"Successfully imported {suppliers.Count}";
            }

            return result;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = "";
            ImportPartDto[]? importedPartDtos = DeserializeXml<ImportPartDto[]>(inputXml, "Parts");
            if (importedPartDtos != null)
            {
                var parts = importedPartDtos
                    .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                    .Select(p => new Part()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity,
                        SupplierId = p.SupplierId
                    })
                    .ToList();

                context.Parts.AddRange(parts);
                context.SaveChanges();

                result = $"Successfully imported {parts.Count}";
            }

            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = "";
            ImportCarDto[]? importedCarDtos = DeserializeXml<ImportCarDto[]>(inputXml, "Cars");
            if (importedCarDtos != null)
            {
                ICollection<Car> carsToImport = new List<Car>();
                foreach (var carDto in importedCarDtos)
                {
                    Car newCar = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    foreach (var part in carDto.Parts.DistinctBy(p => p.Id))
                    {
                        if (!context.Parts.Any(p => p.Id == part.Id))
                        {
                            continue;
                        }

                        PartCar partCar = new PartCar()
                        {
                            PartId = part.Id,
                            Car = newCar
                        };

                        newCar.PartsCars.Add(partCar);
                    }

                    carsToImport.Add(newCar);
                }

                context.Cars.AddRange(carsToImport);
                context.SaveChanges();

                result = $"Successfully imported {carsToImport.Count}";
            }

            return result;
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = "";
            ImportCustomerDto[]? importedCustomerDtos = DeserializeXml<ImportCustomerDto[]>(inputXml, "Customers");
            if (importedCustomerDtos != null)
            {
                var customers = importedCustomerDtos
                    .Select(c => new Customer()
                    {
                        Name = c.Name,
                        BirthDate = c.BirthDate,
                        IsYoungDriver = c.IsYoungDriver
                    })
                    .ToList();

                context.Customers.AddRange(customers);
                context.SaveChanges();

                result = $"Successfully imported {customers.Count}";
            }

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = "";
            ImportSaleDto[] importedSaleDtos = DeserializeXml<ImportSaleDto[]>(inputXml, "Sales");
            if (importedSaleDtos != null)
            {
                var carIds = context.Cars.Select(c => c.Id).ToList();
                ICollection<Sale> salesToImport = new List<Sale>();
                foreach (var saleDto in importedSaleDtos)
                {
                    if (!saleDto.CarId.HasValue ||
                        !carIds.Contains(saleDto.CarId.Value))
                    {
                        continue;
                    }

                    Sale newSale = new Sale()
                    {
                        Discount = saleDto.Discount,
                        CarId = saleDto.CarId.Value,
                        CustomerId = saleDto.CustomerId
                    };

                    salesToImport.Add(newSale);
                }

                context.Sales.AddRange(salesToImport);
                context.SaveChanges();

                result = $"Successfully imported {salesToImport.Count}";
            }

            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new ExportCarsWithDistance()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            return SerializeToXml(carsWithDistance, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsFromBmwMake = context.Cars
                .Where(c => c.Make.Equals("BMW"))
                .Select(c => new ExportBmwCarDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            return SerializeToXml(carsFromBmwMake, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return SerializeToXml(localSuppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new ExportCarWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(p => new ExportPartSimpleDto()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            return SerializeToXml(carsWithParts, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //var customers = context.Sales
            //    .Include(s => s.Customer)
            //    .Include(s => s.Car)
            //    .ThenInclude(c => c.PartsCars)
            //    .ThenInclude(p => p.Part)
            //    .Where(s => s.Customer.Sales.Any())
            //    .ToList();

            //var result = customers
            //    .Select(s => new ExportCustomerDto()
            //    {
            //        FullName = s.Customer.Name,
            //        BoughtCars = s.Customer.Sales.Count,
            //        SpentMoney = s.Customer.IsYoungDriver
            //            ? s.Car.PartsCars
            //                .Sum(pc => Math.Round(pc.Part.Price * 0.95m, 2))
            //            : s.Car.PartsCars
            //                .Sum(pc => Math.Round(pc.Part.Price, 2))
            //    })
            //    .OrderByDescending(pc => pc.SpentMoney)
            //    .ToList();


            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    IsYoungDriver = c.IsYoungDriver,
                    AllPartPricesFromAllCars = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Select(x => x.Part.Price)
                        .ToList()
                })
                .ToList();

            List<ExportCustomerDto> customersExport = new List<ExportCustomerDto>();
            foreach (var customer in customers)
            {
                decimal totalMoneySpent = 0;
                foreach (var partPrice in customer.AllPartPricesFromAllCars)
                {
                    if (customer.IsYoungDriver)
                    {
                        totalMoneySpent += Math.Round(partPrice * 0.95m, 2);
                    }
                    else
                    {
                        totalMoneySpent += partPrice;
                    }
                }

                ExportCustomerDto customerDto = new ExportCustomerDto()
                {
                    FullName = customer.FullName,
                    BoughtCars = customer.BoughtCars,
                    SpentMoney = totalMoneySpent
                };

                customersExport.Add(customerDto);
            }

            customersExport = customersExport.OrderByDescending(c => c.SpentMoney).ToList();

            return SerializeToXml(customersExport, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    CarMake = s.Car.Make,
                    CarModel = s.Car.Model,
                    CarTraveledDistance = s.Car.TraveledDistance,
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price)
                })
                .ToList();

            var result = sales
                .Select(s => new ExportSaleWithDiscountDto()
                {
                    Car = new ExportCarWithPartsDto()
                    {
                        Make = s.CarMake,
                        Model = s.CarModel,
                        TraveledDistance = s.CarTraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.CustomerName,
                    Price = s.Price,
                    PriceWithDiscount = (double)(s.Price * (1 - s.Discount / 100))
                })
                .ToList();

            return SerializeToXml(result, "sales");
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