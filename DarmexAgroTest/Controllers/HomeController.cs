using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DarmexAgroTest.Models;
using Microsoft.AspNetCore.Http;
using DarmexAgroTest.Services;

namespace DarmexAgroTest.Controllers
{
    public class HomeController : Controller
    {
        private DarmexAgroDbContext _darmexAgroDbContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DarmexAgroDbContext darmexAgroDbContext)
        {
            _logger = logger;
            _darmexAgroDbContext = darmexAgroDbContext;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return Redirect("/Authentication/Login");
            }

            ViewBag.UserNameInfo = (string)HttpContext.Session.GetString("Username");

            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }

        public IActionResult Transaksi()
        {
            var costumerService = new CostumerService(_darmexAgroDbContext);
            DateTime time = DateTime.Now;
            ViewBag.TransaksiDate = time.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Costumer = costumerService.GetCostumers();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTransaksi([FromBody]TransaksiViewModel transaksiViewModel)
        {
            var transaksiService = new TransaksiService(_darmexAgroDbContext);
            var returnVal = transaksiService.Transaksi(transaksiViewModel);

            return Json(new { status = true, remarks = "Login Successfull." });
        }

        [HttpGet]
        public IActionResult GetDataProduk()
        {
            var produkService = new ProdukService(_darmexAgroDbContext);
            var data = produkService.GetProdukDetails();
            return Json(data);
        }

        [HttpGet]
        public IActionResult GetDataTransaksi()
        {
            var transaksiService = new TransaksiService(_darmexAgroDbContext);
            var data = transaksiService.GetTransaksis();
            return Json(data);
        }

        [HttpPost]
        public ActionResult GetDataTransaksiView([FromBody] Param param)
        {
            var transaksiService = new TransaksiService(_darmexAgroDbContext);
            var data = transaksiService.GetTransaksiViews(param.Id.ToString());
            return Json(data);
        }

        public class Param
        {
            public Guid Id { get; set; }
        }
    }
}
