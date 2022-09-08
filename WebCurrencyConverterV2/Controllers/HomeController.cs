using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Globalization;
using WebCurrencyConverterV2.Models;


namespace WebCurrencyConverterV2.Controllers
{
   
    public class HomeController : Controller
    {
        

        [HttpGet]
        public IActionResult Index()
        {
            ViewModel currencyList = new ViewModel();
            if (TempData["from"] != null)
            {
                //Query query = (Query)_memory.Get("Query");
                Query query = new Query();
                query.from = (string)TempData["from"];
                query.to = (string)TempData["to"];

                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";
                query.amount = Convert.ToDouble(TempData["amount"], provider);

                currencyList.Currency = APIModel.GetResult(query.from, query.to, query.amount);
                currencyList.list = APIModel.GetList();

                return View(currencyList);
            }
            

            currencyList.list = APIModel.GetList();

            return View(currencyList);
            
        }
        [HttpPost]
        public IActionResult Index(string from, string to, string amount)
        {

            TempData["from"] = from;
            TempData["to"] = to;
            TempData["amount"] = amount;

            return RedirectToAction("Index");
        }

        
    }
}