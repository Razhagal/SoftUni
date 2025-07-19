namespace CarDealer
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using AutoMapper;

    using System.ComponentModel.DataAnnotations;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.DTOs.Import;
    using System.Globalization;

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            mapper = mapperConfig.CreateMapper();

            string jsonFile = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSuppliers(dbContext, jsonFile);
            //string result = ImportParts(dbContext, jsonFile);
            //string result = ImportCars(dbContext, jsonFile);
            //string result = ImportCustomers(dbContext, jsonFile);
            //string result = ImportSales(dbContext, jsonFile);

            //string result = GetOrderedCustomers(dbContext);
            //string result = GetCarsFromMakeToyota(dbContext);
            //string result = GetLocalSuppliers(dbContext);
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //string result = GetTotalSalesByCustomer(dbContext);
            string result = GetSalesWithAppliedDiscount(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = "";
            ImportSupplierDto[]? importedSuppliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            if (importedSuppliersDtos != null)
            {
                ICollection<Supplier> suppliersToImport = new List<Supplier>();
                foreach (var supplierDto in importedSuppliersDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isParsedIsImporter = bool.TryParse(supplierDto.IsImporter, out bool parsedIsImporter);
                    if (!isParsedIsImporter)
                    {
                        continue;
                    }

                    Supplier newSupplier = mapper.Map<ImportSupplierDto, Supplier>(supplierDto);
                    //Supplier newSupplier = new Supplier()
                    //{
                    //    Name = supplierDto.Name,
                    //    IsImporter = parsedIsImporter
                    //};

                    suppliersToImport.Add(newSupplier);
                }

                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();

                result = $"Successfully imported {suppliersToImport.Count}.";
            }

            return result;
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = "";
            ImportPartDto[]? importedPartsDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);
            if (importedPartsDtos != null)
            {
                var suppliersById = context.Suppliers
                    .Select(s => s.Id)
                    .ToList();

                ICollection<Part> partsToImport = new List<Part>();
                foreach (var partDto in importedPartsDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isPriceParsed = decimal.TryParse(partDto.Price, out decimal parsedPrice);
                    bool isQuantityParsed = int.TryParse(partDto.Quantity, out int parsedQuantity);
                    bool isSupplierIdParsed = int.TryParse(partDto.SupplierId, out int parsedSupplierId);
                    if (!isPriceParsed || !isQuantityParsed || !isSupplierIdParsed)
                    {
                        continue;
                    }

                    if (!suppliersById.Contains(parsedSupplierId))
                    {
                        continue;
                    }

                    Part newPart = mapper.Map<ImportPartDto, Part>(partDto);
                    //Part newPart = new Part()
                    //{
                    //    Name = partDto.Name,
                    //    Price = parsedPrice,
                    //    Quantity = parsedQuantity,
                    //    SupplierId = parsedSupplierId
                    //};

                    partsToImport.Add(newPart);
                }

                context.Parts.AddRange(partsToImport);
                context.SaveChanges();

                result = $"Successfully imported {partsToImport.Count}.";
            }

            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = "";

            //var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            //var cars = new List<Car>();
            //var carParts = new List<PartCar>();


            //foreach (var carDto in carsDto)
            //{

            //    var car = new Car
            //    {
            //        Make = carDto.Make,
            //        Model = carDto.Model,
            //        TraveledDistance = long.Parse(carDto.TraveledDistance)
            //    };

            //    foreach (var part in carDto.PartsId.Distinct())
            //    {
            //        var carPart = new PartCar()
            //        {
            //            PartId = int.Parse(part),
            //            Car = car
            //        };

            //        carParts.Add(carPart);
            //    }

            //}

            //context.Cars.AddRange(cars);

            //context.PartsCars.AddRange(carParts);

            //context.SaveChanges();

            //return $"Successfully imported {context.Cars.Count()}.";


            ImportCarDto[]? importedCarDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            if (importedCarDtos != null)
            {
                ICollection<Car> carsToImport = new List<Car>();
                ICollection<PartCar> carsPartsToImport = new List<PartCar>();
                foreach (var carDto in importedCarDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    //bool isDistanceParsed = long.TryParse(carDto.TraveledDistance, out long parsedTraveledDistance);
                    //if (!isDistanceParsed)
                    //{
                    //    continue;
                    //}

                    //bool carPartsAreValid = true;
                    //foreach (string partId in carDto.PartsId)
                    //{
                    //    if (string.IsNullOrEmpty(partId) || !int.TryParse(partId, out int parsedPartId))
                    //    {
                    //        carPartsAreValid = false;
                    //        break;
                    //    }
                    //}

                    //if (!carPartsAreValid)
                    //{
                    //    continue;
                    //}

                    Car newCar = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    carsToImport.Add(newCar);

                    //TODO: Check if part id's are existing Part in DB - wont implement for exercise Judge system

                    foreach (var partId in carDto.PartsId)
                    {
                        PartCar newPartCar = new PartCar()
                        {
                            Car = newCar,
                            PartId = partId
                        };

                        carsPartsToImport.Add(newPartCar);
                    }
                }

                context.Cars.AddRange(carsToImport);
                context.PartsCars.AddRange(carsPartsToImport);
                context.SaveChanges();

                result = $"Successfully imported {carsToImport.Count}.";
            }

            return result;
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    //BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            DefaultContractResolver pascalCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = pascalCaseResolver,
                DateFormatString = "dd/MM/yyyy"
            };

            string jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented, serializerSettings);
            return jsonResult;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make.Equals("Toyota"))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return jsonResult;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return jsonResult;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2")
                        })
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return jsonResult;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithSales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .SelectMany(p => p.Car.PartsCars
                            .Select(pc => pc.Part.Price))
                            .Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(customersWithSales, Formatting.Indented);
            return jsonResult;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscounts = context.Sales
                .Select(s => new
                {
                    CarMake = s.Car.Make,
                    CarModel = s.Car.Model,
                    CarTraveledDistance = s.Car.TraveledDistance,
                    CustomerName = s.Customer.Name,
                    SaleDiscount = s.Discount,
                    Price = s.Car.PartsCars
                        .Select(cp => cp.Part.Price)
                        .Sum()
                })
                .Take(10)
                .ToList();

            var result = salesWithDiscounts
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.CarMake,
                        Model = s.CarModel,
                        TraveledDistance = s.CarTraveledDistance
                    },
                    customerName = s.CustomerName,
                    discount = s.SaleDiscount.ToString("F2"),
                    price = s.Price.ToString("F2"),
                    priceWithDiscount = (s.Price * (1 - (s.SaleDiscount / 100))).ToString("F2")
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
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