using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        //GET api/v1/homes/laptops
        [HttpGet]
        public IActionResult GetLaptops()
        {
            var laptops = laptopService.GetLaptops();
            if (laptops == null) return Content("Laptop is empty");
            return Ok(laptops);
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
