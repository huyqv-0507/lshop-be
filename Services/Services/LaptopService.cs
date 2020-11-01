using System;
using System.Collections.Generic;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Mapster;
using Services.ConvertionModels;
using Services.IServices;

namespace Services.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILaptopRepository laptopRepository;

        public LaptopService(IUnitOfWork unitOfWork, ILaptopRepository laptopRepository)
        {
            this.unitOfWork = unitOfWork;
            this.laptopRepository = laptopRepository;
        }

        public IEnumerable<Laptop> SearchLaptops(string txtSearch)
        {
            var laptops = laptopRepository.GetMany(laps => laps.LaptopName.Contains(txtSearch) || laps.Brand.BrandName.Contains(txtSearch));
            return laptops;
        }

        public IEnumerable<Laptop> GetLaptops()
        {
            return laptopRepository.GetAll().AsEnumerable();
        }

        public IEnumerable<Laptop> GetLaptopsPaging(int page, int pageSize)
        {
            return laptopRepository.GetPaged(page, pageSize);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void AddLaptop(LaptopModel laptopModel)
        {
            Laptop laptop = laptopModel.Adapt<Laptop>();
            laptopRepository.Add(laptop);
        }
    }
}
