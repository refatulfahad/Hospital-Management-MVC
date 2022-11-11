using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public DoctorController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var data=applicationDbContext.tbl_Doctors;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor obj)
        {
            applicationDbContext.tbl_Doctors.Add(obj);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data= applicationDbContext.tbl_Doctors.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Doctor obj)
        {
            applicationDbContext.tbl_Doctors.Update(obj);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = applicationDbContext.tbl_Doctors.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Doctor obj)
        {
            try
            {
                applicationDbContext.tbl_Doctors.Remove(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorTitle = $"{obj.ID} id has been used by child class.If you want to delete it then first you have to delete " +
                    "from child class.";
                return View("Error");
            }

        }
    }
}
