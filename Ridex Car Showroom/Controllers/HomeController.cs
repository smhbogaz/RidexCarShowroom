using Microsoft.AspNetCore.Mvc;
using Ridex_Car_Showroom.DAL;

namespace Ridex_Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult aboutUs() => View();
        public IActionResult cars()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return View(db.Cars.ToList());
            }
        }
        [HttpPost]
        public IActionResult carsSearch(string carmodel = "", int maxpay = int.MaxValue - 1, int year = int.MaxValue - 1)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Cars> model = db.Cars.Where(x =>

                    x.Marka.ToLower().Contains(carmodel.ToLower()) &&
                    x.Fiyat <= maxpay &&
                    x.UretimYili <= year

                                ).ToList();
                return View("cars", model);
            }

        }
        [HttpGet]
        public IActionResult carsFilter(int kisiSayisi = int.MaxValue - 1, string yakitTipi = "", string vitesTipi = "", int uretimYili = int.MaxValue - 1, string marka = "", string model = "")
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Cars> model_ = db.Cars.Where(x =>
                    x.KisiSayisi <= kisiSayisi &&
                    x.YakitTipi.ToLower().Contains(yakitTipi.ToLower()) &&
                    x.VitesTipi.ToLower().Contains(vitesTipi.ToLower()) &&
                    x.UretimYili <= uretimYili &&
                    x.Marka.ToLower().Contains(marka.ToLower()) &&
                    x.Model.ToLower().Contains(model.ToLower())
                ).ToList();
                return View("cars", model_);
            }

        }



        public IActionResult Giris(string uname, string psw)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (db.Members.Any(x => x.Username == uname && x.Password == psw))
                {
                    Members members = db.Members.First(x => x.Username == uname && x.Password == psw);
                    HttpContext.Session.SetString("username",uname);
                    HttpContext.Session.SetString("password",uname);
                    HttpContext.Session.SetString("surname",members.Surname);
                    HttpContext.Session.SetString("name",members.Name);
                    HttpContext.Session.SetInt32("id",members.Id);
                    return RedirectToAction("index","admin");
                }
            }
            return View("index");
        }

        public IActionResult car(int id)
        {
            return View(id);
        }
    }
}