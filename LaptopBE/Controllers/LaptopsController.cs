using System;
using System.Collections.Generic;
using System.Linq;
using LaptopBE.UiModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.ConvertionModels;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopBE.Controllers
{
    [Route("api/v1/laptops")]
    public class LaptopsController : Controller
    {
        private readonly ILaptopService laptopService;
        public LaptopsController(ILaptopService laptopService)
        {
            this.laptopService = laptopService;
        }
        //GET api/v1/laptops
        [HttpGet]
        public IActionResult GetLaptops()
        {
            var laptops = laptopService.GetLaptops();
            if (laptops == null) return Content("Laptop is empty");
            List<LaptopUiModel> laptopModels = new List<LaptopUiModel>();
            foreach (var laptop in laptops)
            {
                laptopModels.Add(laptop.Adapt<LaptopUiModel>());
            }
            //Shuffle list
            return Ok(laptopModels.OrderBy(x => Guid.NewGuid()).ToList());
        }
        //POST api/v1/laptops
        [HttpPost]
        public IActionResult AddLaptop(LaptopModel laptopModel)
        {
            try
            {
                laptopService.AddLaptop(laptopModel);
                laptopService.Save();
            }
            catch (Exception e)
            {
                return BadRequest(laptopModel + e.Message);
            }
            return Ok(laptopModel);
        }

        //GET api/v1/homes/laptops/page=?&size=?
        [HttpGet("/{page}&{pageSize}")]
        public IActionResult GetLaptopsPaging(int page, int pageSize)
        {
            var laptops = laptopService.GetLaptopsPaging(page, pageSize);
            if (laptops == null) return Content("Laptop is empty");
            return Ok(laptops);
        }
    }
}
