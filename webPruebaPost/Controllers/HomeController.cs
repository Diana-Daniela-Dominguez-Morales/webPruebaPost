using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using webPruebaPost.Models;

namespace webPruebaPost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            OrderHedModel orderHedModel = new OrderHedModel();
            OrderDtlModel orderDtlModel = new OrderDtlModel();
         
            var tupleModel = new Tuple<OrderHedModel, OrderDtlModel>(orderHedModel, orderDtlModel);

            return View(tupleModel);

        }

        [HttpPost]
        public IActionResult Index(OrderHedModel model)
        {
            if (ModelState.IsValid)
            {
               
                OrderDtlModel orderDtlModel = new OrderDtlModel(); 
                Tuple<OrderHedModel, OrderDtlModel> tupleModel = new Tuple<OrderHedModel, OrderDtlModel>(model, orderDtlModel);

                TempData["OrderData"] = tupleModel;
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}