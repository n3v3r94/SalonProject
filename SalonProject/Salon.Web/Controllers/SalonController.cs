
namespace Salon.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Salon.Data.Models;
    using Salon.Services;
    using Salon.Services.Models;

    public class SalonController : Controller
    {
        //za da raboti trqbva da registrame service v startup 
        private readonly ISalonServices salonSvc;

        public SalonController(ISalonServices salon)
        {
            this.salonSvc = salon;
           
        }

         [HttpGet]
        public IActionResult All()
        {

            return View(salonSvc.AllSalon());
        }
        [HttpGet]
        [Authorize(Roles = "Salon")]
        public IActionResult Create ()
        {
            
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Salon")]
        public IActionResult Create(Salons salon)
        {
            if (ModelState.IsValid)
            {

                var userName = HttpContext.User.Identity.Name;
                this.salonSvc.Create(salon , userName);
                return RedirectToAction(nameof(All));
            }
            return View(salon);
        }

        [HttpGet]
        [Authorize(Roles = "Salon")]
        public IActionResult Edit(int  id )
        {

            var currentSalon = this.salonSvc.FindSalon(id);
            return View(currentSalon);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Salon")]
        public IActionResult Edit(Salons salons, int id)
        {

            if (ModelState.IsValid)
            {

                salonSvc.Edit(salons, id);
                return RedirectToAction(nameof(All));
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Salon")]
        public IActionResult Delete(int id)
        {

            var currentSalon = this.salonSvc.FindSalon(id);

            return View(currentSalon);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Salon")]
        public IActionResult Delete(int id, string str)
        {
            if (ModelState.IsValid)
            {
                this.salonSvc.Delete(id, str);
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(All));

          
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var currentSalon = this.salonSvc.Details(id);

            return View(currentSalon);
        }

        [HttpGet]
        public IActionResult AddProduct(int id)
        {
            return View(new AddProductView () { SalonId = id });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Salon")]
        public IActionResult AddProduct(AddProductView product,int id)
        {
            if (ModelState.IsValid)
            {
                this.salonSvc.AddProduct(product, id);
                return RedirectToAction(nameof(MySalon));
            }

           return View(product);
        }

        [HttpGet]
        public IActionResult SearchByProduct(string product)
        {
            var result = this.salonSvc.SearchProduct(product);

            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Salon")]
        public IActionResult MySalon()
        {
            var userName = HttpContext.User.Identity.Name;

            return View(this.salonSvc.MySalons(userName));
        }

        [HttpGet]
        public IActionResult ProductWithWorkers(int id)
        {
            return View(this.salonSvc.GetProductWithWorkers(id));
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var product = this.salonSvc.ProductDetails(id);

            return View(product);
        }

       [HttpGet]
        public IActionResult SearchByUser(string email,int id)
        {
            var temp = Request.QueryString;
            var product = this.salonSvc.SearchByUser(email, id);
           return View(product);
        }

        [HttpGet]
        public IActionResult Book()
        {

            return View(this.salonSvc.Book());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddWorker(string id , string role)
        {
            if (ModelState.IsValid)
            {
                this.salonSvc.AddWorker(id, role);
                return RedirectToAction(nameof(MySalon));
            }

            return RedirectToAction(nameof(MySalon));
        
        }


    }

  
}
