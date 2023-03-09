using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Sevice;

namespace App.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetSevice planets;
        private readonly ILogger<PlanetController> logger;

        public PlanetController(PlanetSevice planets, ILogger<PlanetController> logger)
        {
            this.planets = planets;
            this.logger = logger;
        }

        [Route("/danh-sach-cac-hanh-tinh")]
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet =true, Name ="action")]
        public string Name{get; set;}
        public IActionResult Mercury()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Neptune()
        {
            var planet=planets.Where(p=>p.Name==Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("hanhtinh/{id:int}")]
        public IActionResult Infor(int id)
        {
            var planet=planets.Where(p=>p.Id==id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}