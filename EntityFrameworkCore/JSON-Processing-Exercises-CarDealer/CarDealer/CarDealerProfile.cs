﻿namespace CarDealer
{
    using AutoMapper;

    using CarDealer.DTOs.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<ImportPartDto, Part>();
        }
    }
}
