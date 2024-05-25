using Microsoft.AspNetCore.Mvc;
using Ridex_Car_Showroom.DAL;
using System.Reflection;

namespace Ridex_Car_Showroom.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult AccessCheck(string _viewName)
        {
            if (HttpContext.Session.TryGetValue("id", out _))
            {
                return View(viewName: _viewName);
            }
            return RedirectToAction("index", "home");
        }

        public IActionResult Index()
        {
            return AccessCheck(MethodBase.GetCurrentMethod().Name);
        }

        public IActionResult uyelistesi()
        {
            return AccessCheck(MethodBase.GetCurrentMethod().Name);
        }

        public IActionResult uyeekle()
        {
            return AccessCheck(MethodBase.GetCurrentMethod().Name);
        }


        [HttpPost]
        public IActionResult UyeSil(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Members delete = db.Members.Where(x => x.Id == id).First();
                db.Members.Remove(delete);
                db.SaveChanges();
            }
            return View("uyelistesi");
        }

        [HttpPost]
        public IActionResult uyeEkle(string name, string surname, string username, string password)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Members.Add(new Members { Name = name, Surname = surname, Username = username, Password = password });
                db.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public IActionResult carDelete(int carId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Cars cars = db.Cars.Where(x => x.Id == carId).First();
                string silinecekResim = cars.Resim;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", silinecekResim);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                db.Cars.Remove(cars);
                db.SaveChanges();
            }

            return View("index");
        }

        [HttpPost]
        public IActionResult carUpdate(int carId)
        {          
            return View("update",new AppDbContext().Cars.Where(x=>x.Id==carId).First());
        }

        [HttpPost]
        public IActionResult Update(int id,int kisiSayisi,string yakitTipi,string vitesTipi,int uretimYili,string marka,string model,int fiyat)
        {
            Cars cars;
            using (AppDbContext db = new AppDbContext())
            {
                cars = db.Cars.Where(x => x.Id == id).First();
                cars.KisiSayisi = kisiSayisi;
                cars.YakitTipi = yakitTipi;
                cars.VitesTipi = vitesTipi;
                cars.UretimYili = uretimYili;
                cars.Marka = marka;
                cars.Model = model;
                cars.Fiyat = fiyat;
                db.SaveChanges();
            }
            return View("update",cars);
        }
    }
}
