using Hospital_Management.Data;
using Hospital_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;

namespace Hospital_Management.Controllers
{
	public class PatientController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PatientController(ApplicationDbContext _context)
		{
			this._context = _context;
		}
    
		public IActionResult Index()
		{
			//var patientid = (from a in _context.tbl_Patients select a.Id).ToList();

			var data = _context.tbl_Patients.ToList();
			//var doctors = (from a in _context.PatientDoctor
			//			   where a.PatientId.Equals(7)
			//			   select a.Doctor).ToList();
			//var patient = (from a in _context.tbl_Patients where a.Id.Equals(7) select a).FirstOrDefault();
			//var data = new
			//{
			//    PatientDoctor = doctors,
			//    patient = patient
			//};
			return View(data);
		}

		[HttpGet]
		public IActionResult Details(int Id)
		{
			//var data = (from a in _context.PatientDoctor
			//			where a.PatientId.Equals(Id)
			//			select a.Doctor).ToList();

			
            var list = _context.tbl_Doctors.FromSqlRaw($"spSearchDoctorById {Id}").ToList();


            var list2 = _context.spSearchDoctorByIds.FromSqlRaw($"spSearchDoctorById {Id}").ToList();


            //var data = (from a in _context.PatientDoctor
            //			join b in _context.tbl_Doctors
            //			on a.PatientId equals Id 
            //                     select new
            //			{
            //				ID = b.ID,
            //				Name = b.Name,
            //				Phn_Number = b.Phn_Number,
            //				Specialist = b.Specialist
            //			}).ToList();


            //var data1 = (from a in _context.PatientDoctor
            //			from b in _context.tbl_Doctors
            //			where a.PatientId == Id && a.DoctorId == b.ID
            //			select new
            //			{
            //				ID=b.ID,
            //				Name=b.Name,
            //				Phn_Number=b.Phn_Number,
            //				Specialist=b.Specialist,
            //				PatientId=a.PatientId
            //			}).ToList();


            //var query = (from x in _context.PatientDoctor
            //			 join y in _context.tbl_Doctors on
            //			 new
            //			 {
            //				 Key1 = x.PatientId,
            //				 Key2 = x.DoctorId,

            //			 }
            //			 equals
            //			 new
            //			 {
            //				 Key1 = Id,
            //				 Key2 = y.ID,

            //			 }
            //			 into result
            //			 from r in result.DefaultIfEmpty()
            //			 where r.Name!=null && r.Phn_Number!=null && r.Specialist!=null
            //			 select new { r.ID,r.Name,r.Phn_Number,r.Specialist }).ToList();


            //       var query1 =
            //from a in _context.PatientDoctor
            //               join b in _context.tbl_Doctors on new
            //{
            //	key1=a.PatientId,
            //	key2=a.DoctorId
            //} equals new
            //{
            //	key1=Id,
            //	key2=b.ID
            //}
            //select b.ID + " " + b.Name+" "+b.Phn_Number+" "+b.Specialist;
            //foreach (string name in query1)
            //{
            //    Console.WriteLine(name);
            //}

            //var list1 = _context.tbl_Doctors.Include(x => x.patients).ToList();
            //	foreach(var i in list1)
            //		{
            //			foreach(var j in i.patients)
            //			{
            //				Console.WriteLine(j.DoctorId);
            //			}
            //		}


            return View(list2);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var value = _context.tbl_Doctors.Select(x => x.ID).ToList();
			ViewBag.data = value;
            return View();
		}

        [HttpPost]
        public IActionResult Create(Patient obj, List<int> SelectDoctor)
        {
     //      var patient=new Patient
		   //{
			  // Name = name,
			  // Gender = gender,
			  // Age = age,
			  // Phn_Number = phn_Number
		   //};
            _context.tbl_Patients.Add(obj);
            _context.SaveChanges();
			foreach (var item in SelectDoctor)
			{
				var multidata = new PatientDoctor
				{
					DoctorId = item,
					PatientId = obj.Id
				};
				_context.PatientDoctor.Add(multidata);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
        }
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var data = _context.tbl_Patients.Find(id);
            var value = _context.tbl_Doctors.Select(x => x.ID).ToList();
            ViewBag.data = value;
            return View(data);
		}
		[HttpPost]
		public IActionResult Edit(Patient obj,List<int> SelectDoctor)
		{
			_context.tbl_Patients.Update(obj);
			_context.SaveChanges();
			while (true)
			{
                var data = (from a in _context.PatientDoctor
                            where a.PatientId == obj.Id
                            select a).FirstOrDefault();
				if (data == null) break;
                _context.PatientDoctor.Remove(data);
                _context.SaveChanges();
            }
			
            foreach (var item in SelectDoctor)
            {
                var multidata = new PatientDoctor
                {
                    DoctorId = item,
                    PatientId = obj.Id
                };
                _context.PatientDoctor.Add(multidata);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
		}
	}
}
