using Dharati.DbContext1;
using Dharati.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
// using Microsoft.AspNetCore.Http;

namespace Dharati.Controllers
{
    public class HomeController : Controller
    {
        public DharatiContext dbcontext;
        public HomeController(DharatiContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        private readonly ILogger<HomeController> _logger;
    

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("UserSession") != null)
            //{
            //    ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult > Registration(RegistrationModel viewModel)
        {
            await dbcontext.UserNames.AddAsync(viewModel);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Login");
            //return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Login()
        {
            //if (HttpContext.Session.GetString("UserSession") != null)
            //{

            //    return RedirectToAction("Index");
            //}
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegistrationModel user)
        {
            var myuser = dbcontext.UserNames.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (myuser != null)
            {
              //  HttpContext.Session.SetString("UserSession", myuser.UserName);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "login failed";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Category_info()
        {
            string category_ = "Flowers";
            var data = dbcontext.Categories.Where(x=>x.Category == category_).ToList();
            if(data.Count == 0)
            {
                return View("No data founds");
            }
            return View(data);
        }

        public IActionResult Trees_Info()
        {
            string category_ = "Trees";
            var data = dbcontext.Categories.Where(x => x.Category == category_).ToList();
            if (data.Count == 0)
            {
                return View("No data founds");
            }
            return View(data);
        }

        public IActionResult Flowers_Info()
        {
            string category_ = "Flowers";
            var data = dbcontext.Categories.Where(x => x.Category == category_).ToList();
            if (data.Count == 0)
            {
                return View("No data founds");
            }
            return View(data);
        }

        public IActionResult Vegetables_Info()
        {
            string category_ = "Vegetables";
            var data = dbcontext.Categories.Where(x => x.Category == category_).ToList();
            if (data.Count == 0)
            {
                return View("No data founds");
            }
            return View(data);
        }

        public IActionResult Fruits_Info()
        {
            string category_ = "Fruits";
            var data = dbcontext.Categories.Where(x => x.Category == category_).ToList();
            if (data.Count == 0)
            {
                return View("No data founds");
            }
            return View(data);
        }

        public IActionResult Assesories()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult Vlog()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

    

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel category_data)
        {
            await dbcontext.Categories.AddAsync(category_data);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
            //return View();
        }


        public IActionResult View_Cats()
        {
            var registrationData = dbcontext.Categories.ToList();
            return View(registrationData);
        }


        public ActionResult Edit(int id)
        {
            
            var product = dbcontext.Categories.Find(id);
            if (product == null)
            {
                // If no product is found, redirect to an error page or display an error message
                return RedirectToAction("NotFound", "Error");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel product)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Entry(product).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return RedirectToAction("View_Cats");
            }
            return View(product);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
