using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management.Controllers
{
	public class PatientBillController : Controller
	{
		private readonly ApplicationDbContext _context;
		public PatientBillController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
            return View();
		}
		[HttpPost]
		public IActionResult Create(PatientBill obj)
		{
			_context.tbl_PatientBill.Add(obj);
			_context.SaveChanges();
			return RedirectToAction("Index");
        }
		[HttpGet]
		public IActionResult Search(int id)
		{
			var data=(from a in _context.tbl_PatientBill
					 where a.PatientId == id
					 select a).ToList();

            return View(data);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var data = _context.tbl_PatientBill.Find(id);
			return View(data);	
		}
		[HttpPost]
		public IActionResult Edit(PatientBill obj)
		{
			_context.tbl_PatientBill.Update(obj);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
